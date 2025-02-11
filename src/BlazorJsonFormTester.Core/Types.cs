namespace BlazorJsonFormTester;

using System.ComponentModel.DataAnnotations;

public enum RocketStatus: ushort
{
    Ready,

    Ignition,

    Flight
}

[Flags]
[EnumDisplayNames(
    "The Mercury",
    "The Venus",
    "The Mars",
    "The Jupiter",
    "The Saturn",
    "The Uranus",
    "The Neptune"
)]
public enum MissionTargets
{
    Mercury = 1 << 0,

    Venus = 1 << 1,

    Mars = 1 << 2,

    Jupiter = 1 << 3,

    Saturn = 1 << 4,

    Uranus = 1 << 5,

    Neptune = 1 << 6,
}

/// <param name="Name">Name</param>
/// <param name="Weight">Weight in kg</param>
public record Payload(
    string Name,
    double Weight
);

/// <param name="EngineCount">Number of engines @ int (0 &lt;= value &lt;= 10)</param>
/// <param name="HeadlightBrightness">Headlight brightness @ byte</param>
/// <param name="ImprobabilityDriveFlux">Flux of the improbability drive @ long</param>
/// <param name="Storage">Data recording storage size in bytes @ ulong</param>
/// <param name="AmbientTemperature">Ambient temperature in °C @ float</param>
/// <param name="Fuel">Amount of fuel in L @ double</param>
/// <param name="FlightStart">Flight start @ DateTime</param>
/// <param name="FlightDuration">Flight duration @ TimeSpan</param>
/// <param name="EnableTelemetry">Enable telemetry @ bool</param>
/// <param name="Message">Message from mankind @ string (max length)</param>
/// <param name="MissionDataPath">Mission data path @ string (regex)</param>
/// <param name="Status">Rocket status @ enum of ushort</param>
/// <param name="MissionTargets">Mission targets @ flags</param>
/// <param name="MainPayload">Main payload @ object</param>
/// <param name="AdditionalPayloads">Additional payloads @ array of objects</param>
/// <param name="LaunchCoordinates">Launch coordinates @ array of ints</param>
/// <param name="BabelFishDictionary">Babelfish dictionary @ dict of string and string</param>
public record Rocket(

    [property: Range(0, 10)]
    int EngineCount,

    byte HeadlightBrightness,

    long ImprobabilityDriveFlux,

    ulong Storage,

    float AmbientTemperature,

    double Fuel,

    bool EnableTelemetry,

    DateTime? FlightStart,

    TimeSpan FlightDuration,

    [property: StringLength(20)]
    string Message,

    [
        property:
            JsonSchemaExtension("x-helperText", "Example: /path/to/mission/data"),
            RegularExpression(@"^(?:\/[a-zA-Z_][a-zA-Z_0-9]*)+$"), 
            Required /* https://stackoverflow.com/a/32945086 */
    ]
    string MissionDataPath,

    RocketStatus Status,

    MissionTargets MissionTargets,

    Payload MainPayload,

    Payload[] AdditionalPayloads,

    int[] LaunchCoordinates,

    [property: JsonSchemaExtension(
        "x-keyLabel", "Vogon", 
        "x-valueLabel", "English"
    )]
    Dictionary<string, string> BabelFishDictionary
);

/// <param name="EngineCount">Number of engines @ int (0 &lt;= value &lt;= 10)</param>
/// <param name="HeadlightBrightness">Headlight brightness @ byte</param>
/// <param name="ImprobabilityDriveFlux">Flux of the improbability drive @ long</param>
/// <param name="Storage">Data recording storage size in bytes @ ulong</param>
/// <param name="AmbientTemperature">Ambient temperature in °C @ float</param>
/// <param name="Fuel">Amount of fuel in L @ double</param>
/// <param name="EnableTelemetry">Enable telemetry @ bool</param>
/// <param name="FlightStart">Flight start @ DateTime</param>
/// <param name="FlightDuration">Flight duration @ TimeSpan</param>
/// <param name="Message">Message from mankind @ string</param>
/// <param name="MissionDataPath">Mission data path @ string (regex)</param>
/// <param name="Status">Rocket status @ enum of ushort</param>
/// <param name="MissionTargets">Mission targets @ flags</param>
/// <param name="MainPayload">Main payload @ object</param>
/// <param name="AdditionalPayloads">Additional payloads @ array of objects</param>
/// <param name="LaunchCoordinates">Launch coordinates @ array of ints</param>
/// <param name="BabelFishDictionary">Babelfish dictionary @ dict of string and string</param>
public record Rocket_Nullable(

    [property: Range(0, 10)]
    int? EngineCount,

    byte? HeadlightBrightness,

    long? ImprobabilityDriveFlux,

    ulong? Storage,

    float? AmbientTemperature,

    double? Fuel,

    bool? EnableTelemetry,

    DateTime? FlightStart,

    TimeSpan? FlightDuration,

    [property: StringLength(20)]
    string? Message,

    [
        property:
            JsonSchemaExtension("x-helperText", "Example: /path/to/mission/data"),
            RegularExpression(@"^(?:\/[a-zA-Z_][a-zA-Z_0-9]*)+$"),
            Required /* https://stackoverflow.com/a/32945086 */
    ]

    string? MissionDataPath,

    RocketStatus? Status,

    MissionTargets? MissionTargets,

    Payload? MainPayload,

    Payload?[]? AdditionalPayloads,

    int[]? LaunchCoordinates,

    [property: JsonSchemaExtension(
        "x-keyLabel", "Vogon", 
        "x-valueLabel", "English"
    )]
    Dictionary<string, string>? BabelFishDictionary
);