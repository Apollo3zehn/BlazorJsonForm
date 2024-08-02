using System.ComponentModel.DataAnnotations;

/// <summary>
/// The rocket status
/// </summary>
public enum RocketStatus: ushort
{
    /// <summary>
    /// Ready to launch
    /// </summary>
    Ready,

    /// <summary>
    /// Ignition
    /// </summary>
    Ignition,

    /// <summary>
    /// Flight
    /// </summary>
    Flight
}

/// <summary>
/// Mission targets
/// </summary>
[Flags]
public enum MissionTargets
{
    /// <summary>
    /// Merkur
    /// </summary>
    Merkur = 1 << 0,

    /// <summary>
    /// Venus
    /// </summary>
    Venus = 1 << 1,

    /// <summary>
    /// Mars
    /// </summary>
    Mars = 1 << 2,

    /// <summary>
    /// Jupiter
    /// </summary>
    Jupiter = 1 << 3,

    /// <summary>
    /// Saturn
    /// </summary>
    Saturn = 1 << 4,

    /// <summary>
    /// Uranus
    /// </summary>
    Uranus = 1 << 5,

    /// <summary>
    /// Neptun
    /// </summary>
    Neptun = 1 << 6,
}

/// <summary>
/// A rocket payload
/// </summary>
/// <param name="Name">Name</param>
/// <param name="Weight">Weight in kg</param>
public record Payload(
    string Name,
    double Weight
);

/// <summary>
/// A rocket
/// </summary>
/// <param name="EngineCount">Number of engines @ int (0 &lt;= value &lt;= 10)</param>
/// <param name="HeadlightBrightness">Headlight brightness @ byte</param>
/// <param name="ImprobabilityDriveFlux">Flux of the improbability drive @ long</param>
/// <param name="Storage">Data recording storage size in bytes @ ulong</param>
/// <param name="AmbientTemperature">Ambient temperature in °C @ float</param>
/// <param name="Fuel">Amount of fuel in L @ double</param>
/// <param name="EnableTelemetry">Enable telemetry @ bool</param>
/// <param name="Message">Message from mankind @ string</param>
/// <param name="Status">Rocket status @ enum of ushort</param>
/// <param name="MissionTargets">Mission targets @ flags</param>
/// <param name="MainPayload">Main payload @ object</param>
/// <param name="AdditionalPayloads">Additional payloads @ array of objects</param>
/// <param name="LaunchCoordinates">Launch coordinates @ array of ints</param>
public record Rocket(
    [property: Range(0, 10)]
    int EngineCount,
    byte HeadlightBrightness,
    long ImprobabilityDriveFlux,
    ulong Storage,
    float AmbientTemperature,
    double Fuel,
    bool EnableTelemetry,
    [property: StringLength(20)]
    string Message,
    RocketStatus Status,
    MissionTargets MissionTargets,
    Payload MainPayload,
    Payload[] AdditionalPayloads,
    int[] LaunchCoordinates
);

/// <summary>
/// A rocket
/// </summary>
/// <param name="EngineCount">Number of engines @ int (0 &lt;= value &lt;= 10)</param>
/// <param name="HeadlightBrightness">Headlight brightness @ byte</param>
/// <param name="ImprobabilityDriveFlux">Flux of the improbability drive @ long</param>
/// <param name="Storage">Data recording storage size in bytes @ ulong</param>
/// <param name="AmbientTemperature">Ambient temperature in °C @ float</param>
/// <param name="Fuel">Amount of fuel in L @ double</param>
/// <param name="EnableTelemetry">Enable telemetry @ bool</param>
/// <param name="Message">Message from mankind @ string</param>
/// <param name="Status">Rocket status @ enum of ushort</param>
/// <param name="MissionTargets">Mission targets @ flags</param>
/// <param name="MainPayload">Main payload @ object</param>
/// <param name="AdditionalPayloads">Additional payloads @ array of objects</param>
/// <param name="LaunchCoordinates">Launch coordinates @ array of ints</param>
public record Rocket_Nullable(
    [property: Range(0, 10)]
    int? EngineCount,
    byte? HeadlightBrightness,
    long? ImprobabilityDriveFlux,
    ulong? Storage,
    float? AmbientTemperature,
    double? Fuel,
    bool? EnableTelemetry,
    [property: StringLength(20)]
    string? Message,
    RocketStatus? Status,
    MissionTargets? MissionTargets,
    Payload? MainPayload,
    Payload?[]? AdditionalPayloads,
    int[]? LaunchCoordinates
);