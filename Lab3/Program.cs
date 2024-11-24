using Lab3.Vocabulary;
using Lab3.WebApp;

public class Program {
    public static void Main() {
        Vocabulary vocabulary = new Vocabulary("Dictionary.db");

        new WebApp(vocabulary);
    }
}
