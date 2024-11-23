namespace Lab3.WebApp;

using Microsoft.AspNetCore.Builder;
using Lab3.Vocabulary;

public class WebApp {
    public WebApp(Vocabulary vcb) {
        var app = WebApplication.Create();

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}