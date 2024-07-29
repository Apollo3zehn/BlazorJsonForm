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
/// <param name="Message">Message from mankind to the outer space</param>
/// <param name="Manual">An optional manual about how to fly in space</param>
/// <param name="Status">Rocket status</param>
/// <param name="MainPayload">Main payload</param>
/// <param name="AdditionalPayloads">Additional payloads</param>
public record Rocket(
    int EngineCount,
    double Fuel,
    string Message,
    string? Manual,
    RocketStatus Status,
    Payload MainPayload,
    Payload[] AdditionalPayloads
);