namespace Lecture.Tests;
internal class Thing : ISavable
{
    public string Name { get; set; }

    public Thing(string name)
    {
        Name=name;
    }

    public string ToText()
    {
        return $"{nameof(Name)}: {Name}";
    }
}

