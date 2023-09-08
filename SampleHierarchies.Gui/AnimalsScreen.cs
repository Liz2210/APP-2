using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Animals main screen.
/// </summary>
public sealed class AnimalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private readonly IDataService _dataService;

    /// <summary>
    /// Animals screen.
    /// </summary>
    private readonly MammalsScreen _mammalsScreen;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    public AnimalsScreen(IDataService dataService, MammalsScreen mammalsScreen)
    {
        _dataService = dataService;
        _mammalsScreen = mammalsScreen;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            Console.Clear();
            ScreenDefinionService.Show("AnimalsScreen.json", 0);
            ScreenDefinionService.Show("AnimalsScreen.json", 1);
            ScreenDefinionService.Show("AnimalsScreen.json", 2);
            ScreenDefinionService.Show("AnimalsScreen.json", 3);
            ScreenDefinionService.Show("AnimalsScreen.json", 4);
            ScreenDefinionService.Show("AnimalsScreen.json", 5);

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                AnimalsScreenChoices choice = (AnimalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case AnimalsScreenChoices.Mammals:
                        _mammalsScreen.Show();
                        break;

                    case AnimalsScreenChoices.Read:
                        ReadFromFile();
                        break;

                    case AnimalsScreenChoices.Save:
                        SaveToFile();
                        break;

                    case AnimalsScreenChoices.Exit:
                        ScreenDefinionService.Show("AnimalsScreen.json", 6);
                        return;
                }
            }
            catch
            {
                ScreenDefinionService.Show("AnimalsScreen.json", 7);
            }
        }
    }

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// Save to file.
    /// </summary>
    private void SaveToFile()
    {
        try
        {
            ScreenDefinionService.Show("AnimalsScreen.json", 8);
            var fileName = Console.ReadLine();
            if (fileName is null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            _dataService.Write(fileName);
            ScreenDefinionService.Show("AnimalsScreen.json", 9, fileName);
            Console.ReadLine();
        }
        catch
        {
            ScreenDefinionService.Show("AnimalsScreen.json", 10);

        }
    }

    /// <summary>
    /// Read data from file.
    /// </summary>
    private void ReadFromFile()
    {
        try
        {
            ScreenDefinionService.Show("AnimalsScreen.json", 11);
            var fileName = Console.ReadLine();
            if (fileName is null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            _dataService.Read(fileName);
            ScreenDefinionService.Show("AnimalsScreen.json", 12, fileName);
            Console.ReadLine();
        }
        catch
        {
            ScreenDefinionService.Show("AnimalsScreen.json", 13);
        }
    }

    #endregion // Private Methods
}
