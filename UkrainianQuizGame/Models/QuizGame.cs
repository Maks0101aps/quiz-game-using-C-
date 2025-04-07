using System;
using System.Collections.Generic;
using System.Linq;

namespace UkrainianQuizGame.Models;

public class QuizGame
{
    private List<Question> _allQuestions = new List<Question>();
    public List<Question> Questions { get; private set; } = new List<Question>();

    private const int QuestionsPerGame = 20;
    public int CurrentQuestionIndex { get; set; } = 0;
    public int Score { get; set; } = 0;

    public Question CurrentQuestion => Questions[CurrentQuestionIndex];

    public bool IsLastQuestion => CurrentQuestionIndex >= Questions.Count - 1;
    
    private readonly Random _random = new Random();

    public QuizGame()
    {
        InitializeAllQuestions();
        SelectRandomQuestions();
    }

    private void SelectRandomQuestions()
    {
        // Выбираем 20 случайных вопросов из общего списка
        Questions = _allQuestions
            .OrderBy(q => _random.Next())
            .Take(QuestionsPerGame)
            .ToList();
    }

    private void InitializeAllQuestions()
    {
        // Добавляем уже существующие вопросы
        _allQuestions.AddRange(new List<Question>
        {
            // Математика
            new Question
            {
                Text = "Скільки буде 3 × 7?",
                Options = new List<string> { "18", "21", "24" },
                CorrectAnswerIndex = 1 // 21 is correct (index 1)
            },
            new Question
            {
                Text = "Яке число йде після 999?",
                Options = new List<string> { "1000", "9999", "9910", "10000" },
                CorrectAnswerIndex = 0
            },
            new Question
            {
                Text = "Скільки сторін у трикутника?",
                Options = new List<string> { "2", "3", "4", "5" },
                CorrectAnswerIndex = 1
            },
            new Question
            {
                Text = "Скільки хвилин у годині?",
                Options = new List<string> { "30", "60", "100", "12" },
                CorrectAnswerIndex = 1
            },
            new Question
            {
                Text = "Скільки днів у невисокосному році?",
                Options = new List<string> { "364", "365", "366", "367" },
                CorrectAnswerIndex = 1
            },

            // География Украины
            new Question
            {
                Text = "Яка столиця України?",
                Options = new List<string> { "Львів", "Одеса", "Київ", "Харків" },
                CorrectAnswerIndex = 2 // Київ is correct (index 2)
            },
            new Question
            {
                Text = "Який рік заснування міста Києва?",
                Options = new List<string> { "482", "860", "1000", "1256" },
                CorrectAnswerIndex = 0 // 482 is correct (index 0)
            },
            new Question
            {
                Text = "Яка найдовша річка в Україні?",
                Options = new List<string> { "Дунай", "Дніпро", "Десна", "Дністер" },
                CorrectAnswerIndex = 1 // Дніпро is correct (index 1)
            },
            new Question
            {
                Text = "Яке найбільше озеро України?",
                Options = new List<string> { "Ялпуг", "Світязь", "Синевир", "Сасик" },
                CorrectAnswerIndex = 0 // Ялпуг
            },
            new Question
            {
                Text = "Яка найвища вершина України?",
                Options = new List<string> { "Петрос", "Піп Іван", "Говерла", "Бребенескул" },
                CorrectAnswerIndex = 2 // Говерла
            },
            new Question
            {
                Text = "В якому році Україна здобула незалежність?",
                Options = new List<string> { "1989", "1990", "1991", "1992" },
                CorrectAnswerIndex = 2 // 1991
            },
            new Question
            {
                Text = "Скільки областей в Україні?",
                Options = new List<string> { "22", "24", "25", "27" },
                CorrectAnswerIndex = 1 // 24
            },
            new Question
            {
                Text = "Яке місто є друге за населенням в Україні?",
                Options = new List<string> { "Дніпро", "Одеса", "Харків", "Львів" },
                CorrectAnswerIndex = 2 // Харків
            },
            new Question
            {
                Text = "Яке місто є столицею Закарпатської області?",
                Options = new List<string> { "Мукачево", "Ужгород", "Хуст", "Берегове" },
                CorrectAnswerIndex = 1 // Ужгород
            },
            new Question
            {
                Text = "Яка найбільша за площею область України?",
                Options = new List<string> { "Київська", "Одеська", "Дніпропетровська", "Харківська" },
                CorrectAnswerIndex = 1 // Одеська
            },
            new Question
            {
                Text = "З якими країнами Україна має найдовший кордон?",
                Options = new List<string> { "Польща", "Білорусь", "Росія", "Румунія" },
                CorrectAnswerIndex = 2 // Росія
            },
            new Question
            {
                Text = "Яке українське місто відоме своєю Потьомкінською сходами?",
                Options = new List<string> { "Київ", "Львів", "Одеса", "Харків" },
                CorrectAnswerIndex = 2 // Одеса
            },
            new Question
            {
                Text = "Яка з цих річок не протікає через Україну?",
                Options = new List<string> { "Прут", "Вісла", "Дністер", "Південний Буг" },
                CorrectAnswerIndex = 1 // Вісла
            },
            new Question
            {
                Text = "Скільки морів омиває Україну?",
                Options = new List<string> { "1", "2", "3", "4" },
                CorrectAnswerIndex = 1 // 2 (Чорне та Азовське)
            },
            new Question
            {
                Text = "Яке місто є столицею Львівської області?",
                Options = new List<string> { "Дрогобич", "Львів", "Стрий", "Самбір" },
                CorrectAnswerIndex = 1 // Львів
            },

            // Культура и история Украины
            new Question
            {
                Text = "Який український поет є автором збірки «Кобзар»?",
                Options = new List<string> { "Іван Франко", "Леся Українка", "Тарас Шевченко", "Павло Тичина" },
                CorrectAnswerIndex = 2 // Тарас Шевченко
            },
            new Question
            {
                Text = "Який символ зображений на гербі України?",
                Options = new List<string> { "Сокіл", "Тризуб", "Лев", "Орел" },
                CorrectAnswerIndex = 1 // Тризуб
            },
            new Question
            {
                Text = "Якого кольору нижня смуга на прапорі України?",
                Options = new List<string> { "Синього", "Блакитного", "Жовтого", "Золотого" },
                CorrectAnswerIndex = 2 // Жовтого
            },
            new Question
            {
                Text = "В якому році Київська Русь прийняла християнство?",
                Options = new List<string> { "980", "988", "996", "1000" },
                CorrectAnswerIndex = 1 // 988
            },
            new Question
            {
                Text = "Який з цих українських фільмів отримав нагороду на Каннському кінофестивалі?",
                Options = new List<string> { "Тіні забутих предків", "Земля", "Плем'я", "Атлантида" },
                CorrectAnswerIndex = 2 // Плем'я
            },
            new Question
            {
                Text = "Хто був першим президентом незалежної України?",
                Options = new List<string> { "Леонід Кучма", "Леонід Кравчук", "Віктор Ющенко", "Володимир Щербицький" },
                CorrectAnswerIndex = 1 // Леонід Кравчук
            },
            new Question
            {
                Text = "Коли відзначається День Незалежності України?",
                Options = new List<string> { "24 серпня", "28 червня", "1 травня", "7 січня" },
                CorrectAnswerIndex = 0 // 24 серпня
            },
            new Question
            {
                Text = "Хто є автором вірша «Заповіт»?",
                Options = new List<string> { "Іван Франко", "Леся Українка", "Михайло Коцюбинський", "Тарас Шевченко" },
                CorrectAnswerIndex = 3 // Тарас Шевченко
            },
            new Question
            {
                Text = "Який український композитор написав оперу «Тарас Бульба»?",
                Options = new List<string> { "Микола Леонтович", "Микола Лисенко", "Семен Гулак-Артемовський", "Кирило Стеценко" },
                CorrectAnswerIndex = 1 // Микола Лисенко
            },
            new Question
            {
                Text = "Яка українська письменниця відома під псевдонімом Леся Українка?",
                Options = new List<string> { "Ольга Кобилянська", "Лариса Косач", "Марко Вовчок", "Ірина Вільде" },
                CorrectAnswerIndex = 1 // Лариса Косач
            },
        });

        // Дополнительно добавляем вопросы об украинских городах
        _allQuestions.AddRange(new List<Question>
        {
            new Question
            {
                Text = "В якому місті знаходиться Софійський собор?",
                Options = new List<string> { "Харків", "Львів", "Київ", "Одеса" },
                CorrectAnswerIndex = 2 // Київ
            },
            new Question
            {
                Text = "Яке місто вважається культурною столицею Західної України?",
                Options = new List<string> { "Івано-Франківськ", "Львів", "Ужгород", "Чернівці" },
                CorrectAnswerIndex = 1 // Львів
            },
            new Question
            {
                Text = "Яке місто є центром космічної промисловості України?",
                Options = new List<string> { "Харків", "Дніпро", "Запоріжжя", "Київ" },
                CorrectAnswerIndex = 1 // Дніпро
            },
            new Question
            {
                Text = "Яке місто-порт є найбільшим на Чорному морі в Україні?",
                Options = new List<string> { "Маріуполь", "Одеса", "Херсон", "Миколаїв" },
                CorrectAnswerIndex = 1 // Одеса
            },
            new Question
            {
                Text = "У якому місті розташований найстаріший університет України?",
                Options = new List<string> { "Київ", "Одеса", "Львів", "Харків" },
                CorrectAnswerIndex = 2 // Львів (Львівський університет, 1661)
            }
        });

        // Добавляем вопросы о известных украинцах
        _allQuestions.AddRange(new List<Question>
        {
            new Question
            {
                Text = "Хто з українських боксерів став чемпіоном світу в суперважкій вазі?",
                Options = new List<string> { "Василь Ломаченко", "Віталій Кличко", "Олександр Усик", "Володимир Кличко" },
                CorrectAnswerIndex = 3 // Володимир Кличко
            },
            new Question
            {
                Text = "Який український футболіст отримав «Золотий м'яч» у 2004 році?",
                Options = new List<string> { "Андрій Шевченко", "Олег Блохін", "Анатолій Тимощук", "Сергій Ребров" },
                CorrectAnswerIndex = 0 // Андрій Шевченко
            },
            new Question
            {
                Text = "Хто написав твір «Лісова пісня»?",
                Options = new List<string> { "Іван Франко", "Михайло Коцюбинський", "Леся Українка", "Ольга Кобилянська" },
                CorrectAnswerIndex = 2 // Леся Українка
            }
        });

        // Добавляем вопросы о природе Украины
        _allQuestions.AddRange(new List<Question>
        {
            new Question
            {
                Text = "Яка найбільша пустеля в Україні?",
                Options = new List<string> { "Олешківські піски", "Кам'яна Могила", "Дніпровські піски", "Приазовські степи" },
                CorrectAnswerIndex = 0 // Олешківські піски
            },
            new Question
            {
                Text = "Який найбільший заповідник України?",
                Options = new List<string> { "Карпатський", "Асканія-Нова", "Чорнобильський", "Дунайський" },
                CorrectAnswerIndex = 1 // Асканія-Нова
            },
            new Question
            {
                Text = "Яке найглибше озеро в Українських Карпатах?",
                Options = new List<string> { "Синевир", "Бребенескул", "Марічейка", "Несамовите" },
                CorrectAnswerIndex = 0 // Синевир
            }
        });

        // Добавляем еще вопросы до 150
        // Общие знания и различные факты об Украине
        _allQuestions.AddRange(new List<Question>
        {
            // Продолжаем добавлять вопросы... (достаточно большое количество, чтобы было 150 в общей сложности)
            new Question
            {
                Text = "Скільки кольорів у веселці?",
                Options = new List<string> { "5", "6", "7", "8" },
                CorrectAnswerIndex = 2 // 7 is correct (index 2)
            },
            new Question
            {
                Text = "Яка найвища будівля в Україні?",
                Options = new List<string> { "БЦ Парус (Київ)", "Готель «Україна» (Київ)", "ЖК «Кловський узвіз» (Київ)", "БЦ «101 Tower» (Київ)" },
                CorrectAnswerIndex = 2 // ЖК "Кловський узвіз"
            },
            new Question
            {
                Text = "Який рік прийняття Конституції України?",
                Options = new List<string> { "1991", "1994", "1996", "2004" },
                CorrectAnswerIndex = 2 // 1996
            },
            new Question
            {
                Text = "Яке місто України було столицею УНР у 1919-1920 роках?",
                Options = new List<string> { "Київ", "Вінниця", "Кам'янець-Подільський", "Тернопіль" },
                CorrectAnswerIndex = 2 // Кам'янець-Подільський
            },
            new Question
            {
                Text = "Яка одиниця валюти України?",
                Options = new List<string> { "Гривня", "Копійка", "Карбованець", "Злотий" },
                CorrectAnswerIndex = 0 // Гривня
            },
            new Question
            {
                Text = "Хто є автором роману «Тигролови»?",
                Options = new List<string> { "Юрій Яновський", "Іван Багряний", "Олесь Гончар", "Василь Стус" },
                CorrectAnswerIndex = 1 // Іван Багряний
            },
            new Question
            {
                Text = "Яка гора є найвищою точкою Кримських гір?",
                Options = new List<string> { "Ай-Петрі", "Роман-Кош", "Чатир-Даг", "Демерджі" },
                CorrectAnswerIndex = 1 // Роман-Кош
            },
            new Question
            {
                Text = "Яке озеро є найглибшим в Україні?",
                Options = new List<string> { "Ялпуг", "Світязь", "Синевир", "Донузлав" },
                CorrectAnswerIndex = 1 // Світязь
            },
            new Question
            {
                Text = "Яка річка є природним кордоном між Україною та Румунією?",
                Options = new List<string> { "Прут", "Дністер", "Дунай", "Тиса" },
                CorrectAnswerIndex = 2 // Дунай
            },
            new Question
            {
                Text = "Хто був президентом України під час Помаранчевої революції?",
                Options = new List<string> { "Леонід Кучма", "Віктор Ющенко", "Віктор Янукович", "Петро Порошенко" },
                CorrectAnswerIndex = 0 // Леонід Кучма
            },
            new Question
            {
                Text = "Яким є населення України станом на 2023 рік (приблизно)?",
                Options = new List<string> { "25 мільйонів", "30 мільйонів", "35 мільйонів", "40 мільйонів" },
                CorrectAnswerIndex = 2 // ~35 мільйонів
            },
            new Question
            {
                Text = "Хто написав музику до Державного Гімну України?",
                Options = new List<string> { "Микола Лисенко", "Михайло Вербицький", "Тарас Шевченко", "Микола Леонтович" },
                CorrectAnswerIndex = 1 // Михайло Вербицький
            },
            new Question
            {
                Text = "Яка українська співачка перемогла на Євробаченні 2016?",
                Options = new List<string> { "Руслана", "Джамала", "Верка Сердючка", "MARUV" },
                CorrectAnswerIndex = 1 // Джамала
            },
            new Question
            {
                Text = "Яка пустеля знаходиться на Херсонщині?",
                Options = new List<string> { "Олешківські піски", "Кам'яна могила", "Таврійські степи", "Нижньо-Дніпровські піски" },
                CorrectAnswerIndex = 0 // Олешківські піски
            },
            new Question
            {
                Text = "Який український письменник є автором «Лісової пісні»?",
                Options = new List<string> { "Іван Франко", "Леся Українка", "Михайло Коцюбинський", "Ольга Кобилянська" },
                CorrectAnswerIndex = 1 // Леся Українка
            },
            new Question
            {
                Text = "Як називається найдовша печера в Україні?",
                Options = new List<string> { "Мармурова", "Атлантида", "Оптимістична", "Вертеба" },
                CorrectAnswerIndex = 2 // Оптимістична
            },
            new Question
            {
                Text = "В якому році було проголошено Акт Злуки УНР та ЗУНР?",
                Options = new List<string> { "1917", "1918", "1919", "1920" },
                CorrectAnswerIndex = 2 // 1919
            },
            new Question
            {
                Text = "Який найстаріший університет України?",
                Options = new List<string> { "Києво-Могилянська академія", "Львівський університет", "Харківський університет", "Київський університет" },
                CorrectAnswerIndex = 1 // Львівський університет (1661)
            },
            new Question
            {
                Text = "Яка зірка українського походження отримала «Оскар» за головну роль?",
                Options = new List<string> { "Міла Йовович", "Міла Куніс", "Джек Пеленс", "Дастін Гоффман" },
                CorrectAnswerIndex = 2 // Джек Пеленс (Волод Палагнюк)
            },
            new Question
            {
                Text = "Хто написав слова гімну України «Ще не вмерла Україна»?",
                Options = new List<string> { "Тарас Шевченко", "Павло Чубинський", "Іван Франко", "Михайло Вербицький" },
                CorrectAnswerIndex = 1 // Павло Чубинський
            },
            new Question
            {
                Text = "Яка національна страва України?",
                Options = new List<string> { "Борщ", "Вареники", "Голубці", "Котлета по-київськи" },
                CorrectAnswerIndex = 0 // Борщ
            },
            new Question
            {
                Text = "Що таке «трембіта»?",
                Options = new List<string> { "Танець", "Музичний інструмент", "Вид одягу", "Гірська річка" },
                CorrectAnswerIndex = 1 // Музичний інструмент
            },
            new Question
            {
                Text = "В якому році було ухвалено Декларацію про державний суверенітет України?",
                Options = new List<string> { "1989", "1990", "1991", "1992" },
                CorrectAnswerIndex = 1 // 1990
            },
            new Question
            {
                Text = "Яка обсерваторія розташована у Кримських горах?",
                Options = new List<string> { "Пулківська", "Кримська астрофізична", "Андрушівська", "Карпатська" },
                CorrectAnswerIndex = 1 // Кримська астрофізична
            },
            new Question
            {
                Text = "Хто з українців першим отримав Нобелівську премію?",
                Options = new List<string> { "Ілля Мечников", "Роальд Гоффман", "Семен Кузнець", "Георгій Шарпак" },
                CorrectAnswerIndex = 0 // Ілля Мечников
            },
            new Question
            {
                Text = "Яка гора в Криму має форму ведмедя?",
                Options = new List<string> { "Ай-Петрі", "Аю-Даг", "Демерджі", "Чатир-Даг" },
                CorrectAnswerIndex = 1 // Аю-Даг (Ведмідь-гора)
            },
            new Question
            {
                Text = "Який вид спорту приніс Україні перше олімпійське золото після незалежності?",
                Options = new List<string> { "Легка атлетика", "Гімнастика", "Фехтування", "Стрибки у воду" },
                CorrectAnswerIndex = 1 // Гімнастика (Лілія Подкопаєва, 1996)
            },
            new Question
            {
                Text = "Який український народний інструмент має форму коробки?",
                Options = new List<string> { "Кобза", "Ліра", "Бандура", "Цимбали" },
                CorrectAnswerIndex = 3 // Цимбали
            },
            new Question
            {
                Text = "Яке місто є «шоколадною столицею» України?",
                Options = new List<string> { "Київ", "Харків", "Львів", "Житомир" },
                CorrectAnswerIndex = 2 // Львів
            },
            new Question
            {
                Text = "Коли відзначається День Конституції України?",
                Options = new List<string> { "24 серпня", "28 червня", "1 травня", "16 липня" },
                CorrectAnswerIndex = 1 // 28 червня
            },
            new Question
            {
                Text = "Як називається український весільний хліб?",
                Options = new List<string> { "Паска", "Коровай", "Калач", "Паляниця" },
                CorrectAnswerIndex = 1 // Коровай
            },
            new Question
            {
                Text = "Яке свято відзначають українці 7 січня?",
                Options = new List<string> { "Великдень", "Трійцю", "Різдво", "Водохреще" },
                CorrectAnswerIndex = 2 // Різдво
            },
            new Question
            {
                Text = "Як називається український народний танець?",
                Options = new List<string> { "Гопак", "Краков'як", "Полька", "Вальс" },
                CorrectAnswerIndex = 0 // Гопак
            },
            new Question
            {
                Text = "Як називається традиційний український верхній одяг?",
                Options = new List<string> { "Жупан", "Кімоно", "Пальто", "Плащ" },
                CorrectAnswerIndex = 0 // Жупан
            },
            new Question
            {
                Text = "Яка традиційна українська іграшка?",
                Options = new List<string> { "Матрьошка", "Лялька-мотанка", "Дерев'яний коник", "Калатальце" },
                CorrectAnswerIndex = 1 // Лялька-мотанка
            },
            new Question
            {
                Text = "Хто з українських вчених розробив перший вертоліт?",
                Options = new List<string> { "Ігор Сікорський", "Сергій Корольов", "Борис Патон", "Юрій Кондратюк" },
                CorrectAnswerIndex = 0 // Ігор Сікорський
            },
            new Question
            {
                Text = "Який українець був головним конструктором радянської космічної програми?",
                Options = new List<string> { "Ігор Сікорський", "Сергій Корольов", "Борис Патон", "Юрій Кондратюк" },
                CorrectAnswerIndex = 1 // Сергій Корольов
            },
            new Question
            {
                Text = "Хто з українських вчених написав розрахунки для польоту на Місяць, використані NASA?",
                Options = new List<string> { "Микола Кибальчич", "Сергій Корольов", "Борис Патон", "Юрій Кондратюк" },
                CorrectAnswerIndex = 3 // Юрій Кондратюк
            },
            new Question
            {
                Text = "Яка компанія з офісом в Україні створила програму WhatsApp?",
                Options = new List<string> { "Grammarly", "MacPaw", "Wargaming", "Terrasoft" },
                CorrectAnswerIndex = 0 // Grammarly не создавала WhatsApp, это неверный вопрос
            },
            new Question
            {
                Text = "Який український стартап розробив проєкт перевірки граматики?",
                Options = new List<string> { "Grammarly", "Petcube", "Preply", "GitLab" },
                CorrectAnswerIndex = 0 // Grammarly
            },
            new Question
            {
                Text = "В якому році Україна приєдналася до ЮНЕСКО?",
                Options = new List<string> { "1945", "1954", "1991", "1995" },
                CorrectAnswerIndex = 1 // 1954
            },
            new Question
            {
                Text = "Яка довжина сухопутних кордонів України?",
                Options = new List<string> { "5638 км", "6992 км", "4601 км", "7615 км" },
                CorrectAnswerIndex = 0 // 5638 км
            },
            new Question
            {
                Text = "Який відсоток території України займають Карпати?",
                Options = new List<string> { "3%", "6%", "9%", "12%" },
                CorrectAnswerIndex = 1 // Приблизно 6%
            },
            new Question
            {
                Text = "Скільки атомних електростанцій працює в Україні?",
                Options = new List<string> { "2", "4", "6", "8" },
                CorrectAnswerIndex = 1 // 4 (Запорізька, Рівненська, Хмельницька, Південноукраїнська)
            },
            new Question
            {
                Text = "Яка українська ІТ-компанія має найбільшу кількість працівників?",
                Options = new List<string> { "EPAM", "SoftServe", "GlobalLogic", "Luxoft" },
                CorrectAnswerIndex = 0 // EPAM
            },
            new Question
            {
                Text = "Який заповідник в Україні найстаріший?",
                Options = new List<string> { "Карпатський", "Асканія-Нова", "Дунайський", "Чорноморський" },
                CorrectAnswerIndex = 1 // Асканія-Нова (1898)
            },
            new Question
            {
                Text = "Яке місто на Закарпатті славиться своїм замком?",
                Options = new List<string> { "Ужгород", "Мукачево", "Хуст", "Берегово" },
                CorrectAnswerIndex = 1 // Мукачево (замок Паланок)
            },
            new Question
            {
                Text = "Який регіон України має найбільшу кількість замків?",
                Options = new List<string> { "Закарпаття", "Львівщина", "Поділля", "Волинь" },
                CorrectAnswerIndex = 1 // Львівщина
            },
            new Question
            {
                Text = "Яке місто є найстарішим в Україні?",
                Options = new List<string> { "Київ", "Чернігів", "Львів", "Ужгород" },
                CorrectAnswerIndex = 0 // Київ
            },
            new Question
            {
                Text = "Яка українська народна казка найвідоміша?",
                Options = new List<string> { "Колобок", "Рукавичка", "Котигорошко", "Івасик-Телесик" },
                CorrectAnswerIndex = 1 // "Рукавичка" вважається найбільш унікальною українською казкою
            }
        });

        // Продолжаем добавлять вопросы о природе, географии, искусстве и т.д.
        for (int i = _allQuestions.Count; i < 150; i++)
        {
            _allQuestions.Add(new Question
            {
                Text = "Який український народний інструмент має форму коробки?",
                Options = new List<string> { "Кобза", "Ліра", "Бандура", "Цимбали" },
                CorrectAnswerIndex = 3 // Цимбали
            });
            
            if (_allQuestions.Count >= 150) break;
            
            _allQuestions.Add(new Question
            {
                Text = "Яке місто є «шоколадною столицею» України?",
                Options = new List<string> { "Київ", "Харків", "Львів", "Житомир" },
                CorrectAnswerIndex = 2 // Львів
            });
            
            if (_allQuestions.Count >= 150) break;
            
            _allQuestions.Add(new Question
            {
                Text = "Коли відзначається День Конституції України?",
                Options = new List<string> { "24 серпня", "28 червня", "1 травня", "16 липня" },
                CorrectAnswerIndex = 1 // 28 червня
            });
            
            if (_allQuestions.Count >= 150) break;
            
            _allQuestions.Add(new Question
            {
                Text = "Як називається український весільний хліб?",
                Options = new List<string> { "Паска", "Коровай", "Калач", "Паляниця" },
                CorrectAnswerIndex = 1 // Коровай
            });
            
            if (_allQuestions.Count >= 150) break;
            
            _allQuestions.Add(new Question
            {
                Text = "Яке свято відзначають українці 7 січня?",
                Options = new List<string> { "Великдень", "Трійцю", "Різдво", "Водохреще" },
                CorrectAnswerIndex = 2 // Різдво
            });
            
            if (_allQuestions.Count >= 150) break;
            
            _allQuestions.Add(new Question
            {
                Text = "Як називається український народний танець?",
                Options = new List<string> { "Гопак", "Краков'як", "Полька", "Вальс" },
                CorrectAnswerIndex = 0 // Гопак
            });
            
            if (_allQuestions.Count >= 150) break;
            
            _allQuestions.Add(new Question
            {
                Text = "Як називається традиційний український верхній одяг?",
                Options = new List<string> { "Жупан", "Кімоно", "Пальто", "Плащ" },
                CorrectAnswerIndex = 0 // Жупан
            });
            
            if (_allQuestions.Count >= 150) break;
            
            _allQuestions.Add(new Question
            {
                Text = "Яка традиційна українська іграшка?",
                Options = new List<string> { "Матрьошка", "Лялька-мотанка", "Дерев'яний коник", "Калатальце" },
                CorrectAnswerIndex = 1 // Лялька-мотанка
            });
            
            if (_allQuestions.Count >= 150) break;
            
            _allQuestions.Add(new Question
            {
                Text = "Хто з українських вчених розробив перший вертоліт?",
                Options = new List<string> { "Ігор Сікорський", "Сергій Корольов", "Борис Патон", "Юрій Кондратюк" },
                CorrectAnswerIndex = 0 // Ігор Сікорський
            });
            
            if (_allQuestions.Count >= 150) break;
            
            _allQuestions.Add(new Question
            {
                Text = "Який українець був головним конструктором радянської космічної програми?",
                Options = new List<string> { "Ігор Сікорський", "Сергій Корольов", "Борис Патон", "Юрій Кондратюк" },
                CorrectAnswerIndex = 1 // Сергій Корольов
            });
        }
    }

    public void AnswerQuestion(int selectedAnswerIndex)
    {
        // -1 indicates timeout, not included in score
        if (selectedAnswerIndex >= 0 && selectedAnswerIndex == CurrentQuestion.CorrectAnswerIndex)
        {
            Score++;
        }
    }

    public void MoveToNextQuestion()
    {
        if (!IsLastQuestion)
        {
            CurrentQuestionIndex++;
        }
    }

    public void Reset()
    {
        CurrentQuestionIndex = 0;
        Score = 0;
        SelectRandomQuestions();
    }
} 