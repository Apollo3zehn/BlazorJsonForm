using System.ComponentModel.DataAnnotations;

/// <summary>
/// The rocket status
/// </summary>
public enum RocketStatus
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

[Flags]
/// <summary>
/// Mission targets
/// </summary>
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
/// <param name="EngineCount">Number of engines</param>
/// <param name="HeadlightBrightness">Headlight brightness</param>
/// <param name="ImprobabilityDriveFlux">Flux of the improbability drive</param>
/// <param name="Storage">Data recording storage size in bytes</param>
/// <param name="Fuel">Amount of fuel in L</param>
/// <param name="EnableTelemetry">Enable telemetry</param>
/// <param name="Message">Message from mankind to the outer space</param>
/// <param name="Status">Rocket status</param>
/// <param name="MissionTargets">Mission targets</param>
/// <param name="MainPayload">Main payload</param>
/// <param name="AdditionalPayloads">Additional payloads</param>
/// <param name="SpaceCoordinates">Space coordinates</param>
public record Rocket(
    [property: Range(0, 10)]
    int EngineCount,
    byte HeadlightBrightness,
    long ImprobabilityDriveFlux,
    ulong Storage,
    double Fuel,
    bool EnableTelemetry,
    string Message,
    RocketStatus Status,
    MissionTargets MissionTargets,
    Payload MainPayload,
    Payload[] AdditionalPayloads,
    int[] SpaceCoordinates
);