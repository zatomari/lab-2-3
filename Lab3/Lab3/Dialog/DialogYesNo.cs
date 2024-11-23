namespace Lab3.Dialog;

using Lab3.Input;
using Lab3.Vocabulary;

// Класс диалога
public class DialogYesNo : Dialog {
    public DialogYesNo(Vocabulary vcb) : base(
        vcb,
        new Input(
            "Неизвестное слово. Хотите добавить его в словарь (y/n)? ",
            (text) => text == "y" || text == "n",
            "Введите y или n"
        ),
        new DialogNewWord(vcb)
    ) {
    }

    protected override Task<bool> Action(String word) {
        String yesOrNo = input.Single();

        if (yesOrNo == "y") {
            nextDialog?.Run(word);
        }

        return Task.FromResult(false);
    }
}
