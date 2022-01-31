
namespace Lecture
{
    // why use grade instead of letters? We are using specific letters for Grade
    public enum Grade
    {
        // None, // if you don't want a zero value, you can make a "None" member
        F, // 0
        D, // 1
        C, // 2
        B, // 3
        A  // 4
    }

    [Flags]
    public enum FileAttribute : int
    {
        None,
        Hidden,
        ReadOnly,
        System = Hidden & ReadOnly
    }
}
