namespace IDentityDisorder.Commands;

public static class CommandDescription
{
    public const string UlidCommandDescription =
        "The ULID Generation Command offers a flexible and powerful way to create Universally Unique Lexicographically Sortable Identifiers (ULIDs) tailored to your specific needs. With a suite of customizable options, this command ensures that you can generate ULIDs that fit various requirements, from time-based sorting to specific formatting standards.";

    public const string UlidTimestampOptionDescription =
        "Generates a ULID based on the specified timestamp. This option allows for the creation of unique identifiers that are not only unique but also time-ordered, providing a precise moment of generation which is embedded within the ID itself.";

    public const string UlidRandomnessOptionDescription =
        "Specifies the level of randomness in the generated ULID. This option enables control over the entropy used in the ID creation process, allowing for a balance between randomness and predictability according to the user's requirements.";

    public const string UlidUuidFormatOptionDescription =
        "Converts the generated ULID into a UUID format. This option is particularly useful when integrating with systems that require UUID formatted identifiers, ensuring compatibility and ease of integration without losing the benefits and features of ULIDs.";

    public const string UlidUpperCaseOptionDescription =
        "Displays the generated ULID in uppercase. By default, ULIDs are displayed in lowercase if this option is not specified. This option caters to requirements or preferences for case sensitivity in identifiers, allowing for greater flexibility and adherence to specific coding standards or aesthetic choices.";

    public const string UuidCommandDescription =
        "The UUID Generation Command is a straightforward tool designed for creating Universally Unique Identifiers (UUIDs) across a wide array of applications. It supports various UUID versions, allowing for both time-based and random generation methods to suit different needs.";

    public const string UuidUpperCaseOptionDescription =
        "Displays the generated UUID in uppercase. By default, UUIDs are displayed in lowercase if this option is not specified. This option caters to requirements or preferences for case sensitivity in identifiers, allowing for greater flexibility and adherence to specific coding standards or aesthetic choices.";
}
