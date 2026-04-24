// ToastService.cs — serviço de toasts para injeção de dependência
// Registar em Program.cs: builder.Services.AddScoped<IToastService, ToastService>();

namespace BlazorApp.Services;

public record ToastItem(
    Guid Id,
    string? Title,
    string? Description,
    string Variant = "default",  // "default" | "destructive"
    int Duration = 4000
);

public interface IToastService
{
    event Action<ToastItem>? OnShow;
    void Show(string title, string? description = null, string variant = "default", int duration = 4000);
    void Success(string title, string? description = null);
    void Error(string title, string? description = null);
}

public class ToastService : IToastService
{
    public event Action<ToastItem>? OnShow;

    public void Show(string title, string? description = null, string variant = "default", int duration = 4000)
        => OnShow?.Invoke(new ToastItem(Guid.NewGuid(), title, description, variant, duration));

    public void Success(string title, string? description = null)
        => Show(title, description, "default");

    public void Error(string title, string? description = null)
        => Show(title, description, "destructive");
}
