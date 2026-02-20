namespace dawazonBackend.Common.Mail;

/// <summary>
/// Interfaz para el servicio de envío de correos electrónicos.
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Envía un correo electrónico de forma asíncrona e inmediata.
    /// </summary>
    /// <param name="message">El mensaje a enviar.</param>
    /// <returns>Una tarea que representa la operación asíncrona.</returns>
    Task SendEmailAsync(EmailMessage message);
    
    /// <summary>
    /// Encola un correo electrónico para ser enviado en segundo plano.
    /// </summary>
    /// <param name="message">El mensaje a encolar.</param>
    /// <returns>Una tarea que representa la operación asíncrona.</returns>
    Task EnqueueEmailAsync(EmailMessage message);
}