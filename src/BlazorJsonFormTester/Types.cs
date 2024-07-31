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

/// <summary>
/// A rocket payload
/// </summary>
/// <param name="Weight">Weight in kg</param>
public record Payload(
    double Weight
);

/// <summary>
/// A rocket
/// </summary>
/// <param name="EngineCount">Number of engines</param>
/// <param name="Fuel">Amount of fuel in L</param>
/// <param name="EnableTelemetry">Enable telemetry</param>
/// <param name="Message">Message from mankind to the outer space</param>
/// <param name="Status">Rocket status</param>
/// <param name="MainPayload">Main payload</param>
/// <param name="AdditionalPayloads">Additional payloads</param>
/// <param name="SpaceCoordinates">Space coordinates</param>
public record Rocket(
    [property: Range(0, 10)]
    int EngineCount,
    double Fuel,
    bool EnableTelemetry,
    string Message,
    RocketStatus Status,
    Payload MainPayload,
    Payload[] AdditionalPayloads,
    int[] SpaceCoordinates
);