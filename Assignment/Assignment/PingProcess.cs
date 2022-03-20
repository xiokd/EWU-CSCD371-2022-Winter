using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment;

public record struct PingResult(int ExitCode, string? StdOutput);

public class PingProcess
{
    private ProcessStartInfo StartInfo { get; } = new("ping");

    public PingResult Run(string hostNameOrAddress)
    {
        StartInfo.Arguments = hostNameOrAddress;
        StringBuilder? stringBuilder = null;
        void updateStdOutput(string? line) =>
            (stringBuilder??=new StringBuilder()).AppendLine(line);
        Process process = RunProcessInternal(StartInfo, updateStdOutput, default, default);
        return new PingResult( process.ExitCode, stringBuilder?.ToString());
    }

    /* 	1. Implement PingProcess' public Task<PingResult> RunTaskAsync(string hostNameOrAddress) ❌✔ 
		○ First implement public void RunTaskAsync_Success() test method to test PingProcess.RunTaskAsync() using "localhost". ❌✔
        ○ Do NOT use async/await in this implementation. ❌✔
    */
    public Task<PingResult> RunTaskAsync(string hostNameOrAddress)
    {
        Task<PingResult> task = Task.Run(
            () => Run(hostNameOrAddress)
            );

        return task;
    }

    /*	2. Implement PingProcess' async public Task<PingResult> RunAsync(string hostNameOrAddress) ❌✔ 
		○ First implement the public void RunAsync_UsingTaskReturn_Success() test method to test 
            PingProcess.RunAsync() using "localhost" without using async/await. ❌✔
        ○ Also implement the async public Task RunAsync_UsingTpl_Success() test method to test 
            PingProcess.RunAsync() using "localhost" but this time DO using async/await. ❌✔
    */
    async public Task<PingResult> RunAsync(
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        StartInfo.Arguments = hostNameOrAddress;
        StringBuilder? stringBuilder = null;

        void UpdateStdOutput(string? line) =>
            (stringBuilder ??= new StringBuilder()).AppendLine(line);
        
        cancellationToken.ThrowIfCancellationRequested();

        Task<PingResult> task = Task.Run(
            () =>
            {
                Process process = RunProcessInternal(StartInfo, UpdateStdOutput, default, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
                return new PingResult(process.ExitCode, stringBuilder?.ToString());
            }, cancellationToken);

        return await task;
    }

    async public Task<PingResult> RunAsync(params string[] hostNameOrAddresses)
    {
        StringBuilder? stringBuilder = null;
        CancellationToken cancellationToken = default;

        void updateStdOutput(string? line) =>
            (stringBuilder ??= new StringBuilder()).AppendLine(line);

        ParallelQuery<Task<int>>? all = hostNameOrAddresses.AsParallel()
            .Select(async item =>
            {
                StartInfo.Arguments = item;

                Task<PingResult> task = Task.Run(() =>
                {
                    Process process = RunProcessInternal(StartInfo, updateStdOutput, default, cancellationToken);
                    cancellationToken.ThrowIfCancellationRequested();
                    return new PingResult(process.ExitCode, stringBuilder?.ToString());
                }, cancellationToken);
                
                await task.WaitAsync(default(CancellationToken));
                return task.Result.ExitCode;
            });

        await Task.WhenAll(all);
        int total = all.Aggregate(0, (total, item) => total + item.Result);
        return new PingResult(total, stringBuilder?.ToString());
    }

    async public Task<PingResult> RunLongRunningAsync(
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        Task task = null!;
        await task;
        throw new NotImplementedException();
    }

    private Process RunProcessInternal(
        ProcessStartInfo startInfo,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        var process = new Process
        {
            StartInfo = UpdateProcessStartInfo(startInfo)
        };
        return RunProcessInternal(process, progressOutput, progressError, token);
    }

    private Process RunProcessInternal(
        Process process,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        process.EnableRaisingEvents = true;
        process.OutputDataReceived += OutputHandler;
        process.ErrorDataReceived += ErrorHandler;

        try
        {
            if (!process.Start())
            {
                return process;
            }

            token.Register(obj =>
            {
                if (obj is Process p && !p.HasExited)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Win32Exception ex)
                    {
                        throw new InvalidOperationException($"Error cancelling process{Environment.NewLine}{ex}");
                    }
                }
            }, process);


            if (process.StartInfo.RedirectStandardOutput)
            {
                process.BeginOutputReadLine();
            }
            if (process.StartInfo.RedirectStandardError)
            {
                process.BeginErrorReadLine();
            }

            if (process.HasExited)
            {
                return process;
            }
            process.WaitForExit();
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Error running '{process.StartInfo.FileName} {process.StartInfo.Arguments}'{Environment.NewLine}{e}");
        }
        finally
        {
            if (process.StartInfo.RedirectStandardError)
            {
                process.CancelErrorRead();
            }
            if (process.StartInfo.RedirectStandardOutput)
            {
                process.CancelOutputRead();
            }
            process.OutputDataReceived -= OutputHandler;
            process.ErrorDataReceived -= ErrorHandler;

            if (!process.HasExited)
            {
                process.Kill();
            }

        }
        return process;

        void OutputHandler(object s, DataReceivedEventArgs e)
        {
            progressOutput?.Invoke(e.Data);
        }

        void ErrorHandler(object s, DataReceivedEventArgs e)
        {
            progressError?.Invoke(e.Data);
        }
    }

    private static ProcessStartInfo UpdateProcessStartInfo(ProcessStartInfo startInfo)
    {
        startInfo.CreateNoWindow = true;
        startInfo.RedirectStandardError = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.UseShellExecute = false;
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;

        return startInfo;
    }
}