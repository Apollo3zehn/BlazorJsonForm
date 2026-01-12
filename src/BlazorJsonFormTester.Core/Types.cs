namespace BlazorJsonFormTester;

using BlazorJsonFormTester.Core.Localization;
using System.ComponentModel.DataAnnotations;

public enum RocketStatus : ushort
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
    [property: JsonSchemaExtension( "x-label", "Name_label" )]
    string Name,
    [property: JsonSchemaExtension( "x-label", "Weight_label" )]
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

    [property: Range(0, 10),
               JsonSchemaExtension( "x-label", "EngineCount_label" )]
    int EngineCount,

    [property: JsonSchemaExtension( "x-label", "HeadlightBrightness_label" )]
    byte HeadlightBrightness,

    [property: JsonSchemaExtension( "x-label", "ImprobabilityDriveFlux_label" )]
    long ImprobabilityDriveFlux,

    [property: JsonSchemaExtension( "x-label", "Storage_label" )]
    ulong Storage,

    [property: JsonSchemaExtension( "x-label", "AmbientTemperature_label" )]
    float AmbientTemperature,

    [property: JsonSchemaExtension( "x-label", "Fuel_label" )]
    double Fuel,

    [property: JsonSchemaExtension( "x-label", "EnableTelemetry_label" )]
    bool EnableTelemetry,

    [property: JsonSchemaExtension( "x-label", "FlightStart_label" )]
    DateTime? FlightStart,

    [property: JsonSchemaExtension( "x-label", "FlightDuration_label" )]
    TimeSpan FlightDuration,

    [property: StringLength(20),
               JsonSchemaExtension( "x-label", "Message_label" )]
    string Message,

    [
        property:
            JsonSchemaExtension(
                "x-label", "MissionDataPath_label",
                "x-helperText", "Example: /path/to/mission/data"
            ),
            RegularExpression(@"^(?:\/[a-zA-Z_][a-zA-Z_0-9]*)+$"),
            Required /* https://stackoverflow.com/a/32945086 */
    ]
    string MissionDataPath,

    [property: JsonSchemaExtension( "x-label", "Status_label" )]
    RocketStatus Status,

    [property: JsonSchemaExtension( "x-label", "MissionTargets_label" )]
    MissionTargets MissionTargets,

    [property: JsonSchemaExtension( "x-label", "MainPayload_label" )]
    Payload MainPayload,

    [property: JsonSchemaExtension( "x-label", "AdditionalPayloads_label" )]
    Payload[] AdditionalPayloads,

    [property: JsonSchemaExtension( "x-label", "LaunchCoordinates_label" )]
    int[] LaunchCoordinates,

    [property: JsonSchemaExtension(
        "x-label", "BabelFishDictionary_label",
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

    [property: Range(0, 10),
               JsonSchemaExtension( "x-label", "EngineCount_label" )]
    int? EngineCount,

    [property: JsonSchemaExtension( "x-label", "HeadlightBrightness_label" )]
    byte? HeadlightBrightness,

    [property: JsonSchemaExtension( "x-label", "ImprobabilityDriveFlux_label" )]
    long? ImprobabilityDriveFlux,

    [property: JsonSchemaExtension( "x-label", "Storage_label" )]
    ulong? Storage,

    [property: JsonSchemaExtension( "x-label", "AmbientTemperature_label" )]
    float? AmbientTemperature,

    [property: JsonSchemaExtension( "x-label", "Fuel_label" )]
    double? Fuel,

    [property: JsonSchemaExtension( "x-label", "EnableTelemetry_label" )]
    bool? EnableTelemetry,

    [property: JsonSchemaExtension( "x-label", "FlightStart_label" )]
    DateTime? FlightStart,

    [property: JsonSchemaExtension( "x-label", "FlightDuration_label" )]
    TimeSpan? FlightDuration,

    [property: StringLength(20),
               JsonSchemaExtension( "x-label", "Message_label" )]
    string? Message,

    [
        property:
            JsonSchemaExtension(
                "x-label", "MissionDataPath_label",
                "x-helperText", "Example: /path/to/mission/data"
            ),
            RegularExpression(@"^(?:\/[a-zA-Z_][a-zA-Z_0-9]*)+$"),
            Required /* https://stackoverflow.com/a/32945086 */
    ]
    string? MissionDataPath,

    [property: JsonSchemaExtension( "x-label", "Status_label" )]
    RocketStatus? Status,

    [property: JsonSchemaExtension( "x-label", "MissionTargets_label" )]
    MissionTargets? MissionTargets,

    [property: JsonSchemaExtension( "x-label", "MainPayload_label" )]
    Payload? MainPayload,

    [property: JsonSchemaExtension( "x-label", "AdditionalPayloads_label" )]
    Payload?[]? AdditionalPayloads,

    [property: JsonSchemaExtension( "x-label", "LaunchCoordinates_label" )]
    int[]? LaunchCoordinates,

    [property: JsonSchemaExtension(
        "x-label", "BabelFishDictionary_label",
        "x-keyLabel", "Vogon",
        "x-valueLabel", "English"
    )]
    Dictionary<string, string>? BabelFishDictionary
);