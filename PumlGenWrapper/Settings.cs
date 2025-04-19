namespace PumlGenWrapper;

public class Settings
{
    public required string InputPath { get; init; }
    public required string OutputPath { get; init; }
    public required string ExcludePaths { get; init; }
    public required bool Dir { get; init; }
    public required bool Public { get; init; }
    public required bool CreateAssociation { get; init; }
    public required bool AllInOne { get; init; }
    public required bool AttributeRequired { get; init; }
    public required bool ExcludeUmlBeginEndTags { get; init; }
    public required bool RunSeparate { get; init; }
}