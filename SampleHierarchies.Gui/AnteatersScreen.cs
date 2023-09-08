using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Anteater screen.
    /// </summary>
    public sealed class AnteatersScreen : Screen
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
        public AnteatersScreen(IDataService dataService)
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
                ScreenDefinionService.Show("AnteatersScreen.json", 0);
                ScreenDefinionService.Show("AnteatersScreen.json", 1);
                ScreenDefinionService.Show("AnteatersScreen.json", 2);
                ScreenDefinionService.Show("AnteatersScreen.json", 3);
                ScreenDefinionService.Show("AnteatersScreen.json", 4);
                ScreenDefinionService.Show("AnteatersScreen.json", 5);
                ScreenDefinionService.Show("AnteatersScreen.json", 6);

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    AnteaterScreenChoices choice = (AnteaterScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case AnteaterScreenChoices.List:
                            ListAnteater();
                            Console.ReadLine();
                            break;

                        case AnteaterScreenChoices.Create:
                            AddAnteater();
                            Console.ReadLine();
                            break;

                        case AnteaterScreenChoices.Delete:
                            DeleteAnteater();
                            Console.ReadLine();
                            break;

                        case AnteaterScreenChoices.Modify:
                            EditAnteaterMain();
                            Console.ReadLine();
                            break;

                        case AnteaterScreenChoices.Exit:
                            ScreenDefinionService.Show("AnteatersScreen.json", 7);
                            Console.ReadLine();
                            return;
                    }
                }
                catch
                {
                    ScreenDefinionService.Show("AnteatersScreen.json", 8);
                    Console.ReadLine();
                }
            }
        }

        #endregion // Public Methods

        #region Private Methods

        /// <summary>
        /// List all anteater's.
        /// </summary>
        private void ListAnteater()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Anteaters is not null &&
                _dataService.Animals.Mammals.Anteaters.Count > 0)
            {
                ScreenDefinionService.Show("AnteatersScreen.json", 9);
                int i = 1;
                foreach (Anteater anteater in _dataService.Animals.Mammals.Anteaters)
                {
                    ScreenDefinionService.Show("AnteatersScreen.json", 10, i.ToString());
                    anteater.Display();
                    i++;
                }
            }
            else
            {
                ScreenDefinionService.Show("AnteatersScreen.json", 11);
            }
        }

        /// <summary>
        /// Add an anteater.
        /// </summary>
        private void AddAnteater()
        {
            try
            {
                Anteater anteater = AddEditAnteater();
                _dataService?.Animals?.Mammals?.Anteaters?.Add(anteater);
                ScreenDefinionService.Show("AnteatersScreen.json", 12, anteater.Name);
            }
            catch
            {
                ScreenDefinionService.Show("AnteatersScreen.json", 13);
            }
        }

        /// <summary>
        /// Deletes an anteater.
        /// </summary>
        private void DeleteAnteater()
        {
            try
            {
                ScreenDefinionService.Show("AnteatersScreen.json", 14);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Anteater? anteater = (Anteater?)(_dataService?.Animals?.Mammals?.Anteaters
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (anteater is not null)
                {
                    _dataService?.Animals?.Mammals?.Anteaters?.Remove(anteater);
                    ScreenDefinionService.Show("AnteatersScreen.json", 15, anteater.Name);
                }
                else
                {
                    ScreenDefinionService.Show("AnteatersScreen.json", 16);
                }
            }
            catch
            {
                ScreenDefinionService.Show("AnteatersScreen.json", 17);
            }
        }

        /// <summary>
        /// Edits an existing anteater after choice made.
        /// </summary>
        private void EditAnteaterMain()
        {
            try
            {
                ScreenDefinionService.Show("AnteatersScreen.json", 18);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Anteater? anteater = (Anteater?)(_dataService?.Animals?.Mammals?.Anteaters?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (anteater is not null)
                {
                    Anteater anteaterEdited = AddEditAnteater();
                    anteater.Copy(anteaterEdited);
                    ScreenDefinionService.Show("AnteatersScreen.json", 19);
                    anteater.Display();
                }
                else
                {
                    ScreenDefinionService.Show("AnteatersScreen.json", 20);
                }
            }
            catch
            {
                ScreenDefinionService.Show("AnteatersScreen.json", 21);
            }
        }

        /// <summary>
        /// Adds/edits specific anteater.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Anteater AddEditAnteater()
        {
            ScreenDefinionService.Show("AnteatersScreen.json", 22);
            string? name = Console.ReadLine();
            ScreenDefinionService.Show("AnteatersScreen.json", 23);
            string? ageAsString = Console.ReadLine();
            ScreenDefinionService.Show("AnteatersScreen.json", 24);
            string? snoutLengthAsString = Console.ReadLine();
            ScreenDefinionService.Show("AnteatersScreen.json", 25);
            string? sizeAsString = Console.ReadLine();
            ScreenDefinionService.Show("AnteatersScreen.json", 26);
            string? diet = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (snoutLengthAsString is null)
            {
                throw new ArgumentNullException(nameof(snoutLengthAsString));
            }
            if (sizeAsString is null)
            {
                throw new ArgumentNullException(nameof(sizeAsString));
            }
            if (diet is null)
            {
                throw new ArgumentNullException(nameof(diet));
            }
            int age = Int32.Parse(ageAsString);
            int size = Int32.Parse(sizeAsString);
            int snoutLength = Int32.Parse(snoutLengthAsString);
            Anteater anteater = new Anteater(name, age, snoutLength, size, diet);
            return anteater;
        }

        #endregion // Private Methods
    }
}
