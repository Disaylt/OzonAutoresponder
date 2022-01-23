WriteDecriptions();
CreateTemplate();
TimerCallback timerCallback = new TimerCallback(StartResponder);
Timer timer = new Timer(timerCallback, null, 0, 1000 * 60 * GlobalVaribles.Settings.TimeOut);
CheckExit();


void WriteDecriptions()
{
    string[] decriptions = File.ReadAllLines($@"{GlobalVaribles.ProjectDirectory}descriptions.txt");
    foreach (string decription in decriptions)
    {
        Console.WriteLine(decription);
    }
}

void CreateTemplate()
{
    Console.WriteLine("Создать шаблон заполнения ексель ? Y/N - Да/Нет");
    string letter = Console.ReadLine();
    if(letter.ToUpper() == "Y")
    {
        ExcelAnswersTemplateCreator.Create(GlobalVaribles.ProjectDirectory);
        Console.WriteLine($"\nШаблон создан по пути: {GlobalVaribles.ProjectDirectory}");
    }
}

async void StartResponder(object obj)
{ 
    string pathToStandardExcelFile = $"{GlobalVaribles.TemplatesDirectory}Answers.xlsx";
    string brandsDirectory = $@"{GlobalVaribles.TemplatesDirectory}Brands\";
    string pathToBlackList = $"{GlobalVaribles.ProjectDirectory}BlackList.txt";
    string pathToIdTemplate = $"{GlobalVaribles.TemplatesDirectory}IdTemplate.xlsx";

    AutoresponderExcel autoresponderExcel = new AutoresponderExcel(pathToStandardExcelFile, brandsDirectory, pathToBlackList, pathToIdTemplate);
    OzonHttpClient client = new OzonHttpClient();
    Feedbacks feedbacks = client.GetFeedbackListAsync().Result;
    if(feedbacks.Result != null)
    {
        foreach (var feedback in feedbacks.Result)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine($"Текущая дата: {DateTime.Now}");
            Console.WriteLine($"Дата отзыва: {feedback.CreatedAt.AddHours(3)}");
            string feedbackText = $"Name: {feedback.AuthorName}\nComment: {feedback.Text.Comment}\nPositive: {feedback.Text.Positive}\nNegative: {feedback.Text.Negative}";
            string answer = autoresponderExcel.GetResponseText(feedbackText, SellerProfile.BrandId, feedback.Sku, feedback.AuthorName);
            Console.WriteLine(feedbackText);
            Console.WriteLine($"Ответ: {answer}");
            string bodyRequest = JsonBuilder.GetBodyAnswer(answer, feedback.Id.ToString());
            if (GlobalVaribles.Settings.IsAnswer && !string.IsNullOrEmpty(answer))
            {
                string? response = await client.PostAnswer(bodyRequest);
                if (response != null)
                {
                    Console.WriteLine($"Ответ отправлен.");
                }
                else
                {
                    Console.WriteLine($"Ошибка при отправлении запроса.");
                }
            }
            else
            {
                Console.WriteLine("Отправка отменена настройками проекта. Либо составленый отзыв был пустым.");
            }
            Thread.Sleep(1000 * GlobalVaribles.Settings.TimeoutAnswer);
        }
    }
    else
    {
        Console.WriteLine($"Неудалось получить список отзывов.");
    }

}

void CheckExit()
{
    while(true)
    {
        Console.WriteLine("Введите '/exit' для выхода");
        string command = Console.ReadLine() ?? string.Empty;
        if (command == "/exit")
        {
            Environment.Exit(0);
        }
    }
}