using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class MammalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Mammals screen.
    /// </summary>
    
    private readonly DogsScreen _dogsScreen;
    private readonly AnteatersScreen _anteatersScreen;
    private readonly TurkeysScreen _turkeysScreen;
    private readonly HedgehogsScreen _hedgehogScreen;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="dogsScreen">Dogs screen</param>
    public MammalsScreen(DogsScreen dogsScreen, AnteatersScreen anteatersScreen, TurkeysScreen turkeysScreen, HedgehogsScreen hedgehogScreen)
    {
        _dogsScreen = dogsScreen;
        _anteatersScreen = anteatersScreen;
        _turkeysScreen = turkeysScreen;
        _hedgehogScreen = hedgehogScreen;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            Console.Clear();
            ScreenDefinionService.Show("MammalsScreen.json", 0);
            ScreenDefinionService.Show("MammalsScreen.json", 1);
            ScreenDefinionService.Show("MammalsScreen.json", 2);
            ScreenDefinionService.Show("MammalsScreen.json", 3);
            ScreenDefinionService.Show("MammalsScreen.json", 4);
            ScreenDefinionService.Show("MammalsScreen.json", 5);
            ScreenDefinionService.Show("MammalsScreen.json", 6);
            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MammalsScreenChoices choice = (MammalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MammalsScreenChoices.Dogs:
                        _dogsScreen.Show(); break;
                    case MammalsScreenChoices.Anteaters:
                        _anteatersScreen.Show(); break;
                    case MammalsScreenChoices.Turkeys:
                        _turkeysScreen.Show(); break;
                    case MammalsScreenChoices.Hedgehogs:
                        _hedgehogScreen.Show(); break;
                    case MammalsScreenChoices.Exit:
                        ScreenDefinionService.Show("MammalsScreen.json", 7);
                        return;
                }
            }
            catch
            {
                ScreenDefinionService.Show("MammalsScreen.json", 8);
            }
        }
    }

    #endregion // Public Methods
}
