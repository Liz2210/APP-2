using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Turkey screen.
    /// </summary>
    public sealed class TurkeysScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Data service.
        /// </summary>
        private readonly IDataService _dataService;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        public TurkeysScreen(IDataService dataService)
        {
            _dataService = dataService;
        }

        #endregion Properties And Ctor

        #region Public Methods

        /// <inheritdoc/>
        public override void Show()
        {
            while (true)
            {
                Console.Clear();
                ScreenDefinionService.Show("TurkeysScreen.json", 0);
                ScreenDefinionService.Show("TurkeysScreen.json", 1);
                ScreenDefinionService.Show("TurkeysScreen.json", 2);
                ScreenDefinionService.Show("TurkeysScreen.json", 3);
                ScreenDefinionService.Show("TurkeysScreen.json", 4);
                ScreenDefinionService.Show("TurkeysScreen.json", 5);
                ScreenDefinionService.Show("TurkeysScreen.json", 6);

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    TurkeyScreenChoices choice = (TurkeyScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case TurkeyScreenChoices.List:
                            ListTurkey();
                            Console.ReadLine();
                            break;

                        case TurkeyScreenChoices.Create:
                            AddTurkey();
                            Console.ReadLine();
                            break;

                        case TurkeyScreenChoices.Delete:
                            DeleteTurkey();
                            Console.ReadLine();
                            break;

                        case TurkeyScreenChoices.Modify:
                            EditTurkeyMain();
                            Console.ReadLine();
                            break;

                        case TurkeyScreenChoices.Exit:
                            ScreenDefinionService.Show("TurkeysScreen.json", 7);
                            Console.ReadLine();
                            return;
                    }
                }
                catch
                {
                    ScreenDefinionService.Show("TurkeysScreen.json", 8);
                    Console.ReadLine();
                }
            }
        }

        #endregion // Public Methods

        #region Private Methods

        /// <summary>
        /// List all turkeys.
        /// </summary>
        private void ListTurkey()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Turkeys is not null &&
                _dataService.Animals.Mammals.Turkeys.Count > 0)
            {
                ScreenDefinionService.Show("TurkeysScreen.json", 9);
                int i = 1;
                foreach (Turkey turkey in _dataService.Animals.Mammals.Turkeys)
                {
                    ScreenDefinionService.Show("TurkeysScreen.json", 10, i.ToString());
                    turkey.Display();
                    i++;
                }
            }
            else
            {
                ScreenDefinionService.Show("TurkeysScreen.json", 11);
            }
        }

        /// <summary>
        /// Add a turkey.
        /// </summary>
        private void AddTurkey()
        {
            try
            {
                Turkey turkey = AddEditTurkey();
                _dataService?.Animals?.Mammals?.Turkeys?.Add(turkey);
                ScreenDefinionService.Show("TurkeysScreen.json", 12, turkey.Name);
            }
            catch
            {
                ScreenDefinionService.Show("TurkeysScreen.json", 13);
            }
        }

        /// <summary>
        /// Deletes a turkey.
        /// </summary>
        private void DeleteTurkey()
        {
            try
            {
                ScreenDefinionService.Show("TurkeysScreen.json", 14);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Turkey? turkey = (Turkey?)(_dataService?.Animals?.Mammals?.Turkeys
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (turkey is not null)
                {
                    _dataService?.Animals?.Mammals?.Turkeys?.Remove(turkey);
                    ScreenDefinionService.Show("TurkeysScreen.json", 15, turkey.Name);
                }
                else
                {
                    ScreenDefinionService.Show("TurkeysScreen.json", 16);
                }
            }
            catch
            {
                ScreenDefinionService.Show("TurkeysScreen.json", 17);
            }
        }

        /// <summary>
        /// Edits an existing turkey after choice made.
        /// </summary>
        private void EditTurkeyMain()
        {
            try
            {
                ScreenDefinionService.Show("TurkeysScreen.json", 18);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Turkey? turkey = (Turkey?)(_dataService?.Animals?.Mammals?.Turkeys?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (turkey is not null)
                {
                    Turkey turkeyEdited = AddEditTurkey();
                    turkey.Copy(turkeyEdited);
                    ScreenDefinionService.Show("TurkeysScreen.json", 19);
                    turkey.Display();
                }
                else
                {
                    ScreenDefinionService.Show("TurkeysScreen.json", 20);
                }
            }
            catch
            {
                ScreenDefinionService.Show("TurkeysScreen.json", 21);
            }
        }

        /// <summary>
        /// Adds/edits specific turkey.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Turkey AddEditTurkey()
        {
            ScreenDefinionService.Show("TurkeysScreen.json", 22);
            string? name = Console.ReadLine();
            ScreenDefinionService.Show("TurkeysScreen.json", 23);
            string? ageAsString = Console.ReadLine();
            ScreenDefinionService.Show("TurkeysScreen.json", 24);
            string? color = Console.ReadLine();
            ScreenDefinionService.Show("TurkeysScreen.json", 25);
            string? sound = Console.ReadLine();
            ScreenDefinionService.Show("TurkeysScreen.json", 26);
            string? eggProductionRateAsString = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (color is null)
            {
                throw new ArgumentNullException(nameof(color));
            }
            if (sound is null)
            {
                throw new ArgumentNullException(nameof(sound));
            }
            if (eggProductionRateAsString is null)
            {
                throw new ArgumentNullException(nameof(eggProductionRateAsString));
            }
            int age = Int32.Parse(ageAsString);
            int eggProductionRate = Int32.Parse(eggProductionRateAsString);
            Turkey turkey = new Turkey(name, age, color, sound, eggProductionRate);
            return turkey;
        }

        #endregion // Private Methods
    }
}
