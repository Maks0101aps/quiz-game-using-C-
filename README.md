# Українська Вікторина (Ukrainian Quiz Game)

Інтерактивна вікторина з питаннями на різні теми, розроблена з використанням C# та Avalonia UI.

## Системні вимоги

- .NET SDK 8.0 або новіше
- Підтримка Linux, Windows або macOS

## Встановлення

### Fedora Linux

```bash
# Встановлення .NET SDK
sudo dnf install dotnet-sdk-8.0

# Клонування репозиторію
git clone https://github.com/yourusername/ukrainian-quiz-game.git
cd ukrainian-quiz-game
```

### Ubuntu Linux

```bash
# Встановлення залежностей
wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

# Встановлення .NET SDK
sudo apt-get update
sudo apt-get install -y dotnet-sdk-8.0
```

## Запуск програми

```bash
cd UkrainianQuizGame
dotnet run
```

## Як грати

1. Запустіть програму, щоб почати гру
2. Читайте питання та обирайте правильну відповідь:
   - Натиснувши на кнопку з відповіддю
   - Або натиснувши відповідну цифрову клавішу на клавіатурі (1, 2, 3, 4)
3. Отримуйте миттєвий зворотній зв'язок щодо вашої відповіді
4. Після завершення тесту побачите свій результат
5. Можете зіграти знову, натиснувши кнопку "Грати знову"

## Технології

- C# з .NET 8.0
- Avalonia UI для кросплатформного графічного інтерфейсу
- MVVM (Model-View-ViewModel) патерн проектування