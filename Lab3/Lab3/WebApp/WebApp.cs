namespace Lab3.WebApp;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using Lab3.Vocabulary;
using Lab3.Word;

public class WebApp {
    private Vocabulary vcb;
    private WebApplication app;

    public WebApp(Vocabulary vcb) {
        this.vcb = vcb;
        app = WebApplication.Create();

        InitRoot();
        InitHas();
        InitGetWords();
        InitGetKnownWords();

        app.Run();
    }

    private void InitRoot() {
        app.MapGet("/", () =>
            "Usage:\n\n" +
            "/has/word — true — если слово есть в базе данных, false — если нет\n\n" +
            "/words/root — список всех слов в базе данных с корнем root\n\n" +
            "/known-words/word — список всех слов в базе данных, однокоренных переданному"
        );
    }

    private void InitHas() {
        app.MapGet("/api/has/{word}", async (string word) => {
            bool result = await vcb.Has(word);

            return Results.Json(result);
        });
    }

    private void InitGetWords() {
        app.MapGet("/api/words/{root}", async (string root) => {
            Word[] words = await vcb.GetWords(root);
            string[] result = new string[words.Length];

            for (int i = 0; i < words.Length; i++) {
                result[i] = words[i].ToString();
            }

            return Results.Json(result);
        });
    }

    private void InitGetKnownWords() {
        app.MapGet("/api/known-words/{word}", async (string word) => {
            Word[] words = await vcb.GetKnownWords(word);
            string[] result = new string[words.Length];

            for (int i = 0; i < words.Length; i++) {
                result[i] = words[i].Output();
            }

            return Results.Json(result);
        });
    }
}
