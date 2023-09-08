using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Hedgehog's screen.
    /// </summary>
    public sealed class HedgehogsScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Data service.
        /// </summary>
        private IDataService _dataService;
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        public HedgehogsScreen(IDataService dataService)
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
                ScreenDefinionService.Show("HedgehogsScreen.json", 0);
                ScreenDefinionService.Show("HedgehogsScreen.json", 1);
                ScreenDefinionService.Show("HedgehogsScreen.json", 2);
                ScreenDefinionService.Show("HedgehogsScreen.json", 3);
                ScreenDefinionService.Show("HedgehogsScreen.json", 4);
                ScreenDefinionService.Show("HedgehogsScreen.json", 5);
                ScreenDefinionService.Show("HedgehogsScreen.json", 6);

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    HedgehogScreenChoices choice = (HedgehogScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case HedgehogScreenChoices.List:
                            ListHedgehog();
                            Console.ReadLine();
                            break;

                        case HedgehogScreenChoices.Create:
                            AddHedgehog();
                            Console.ReadLine();
                            break;

                        case HedgehogScreenChoices.Delete:
                            DeleteHedgehog();
                            Console.ReadLine();
                            break;

                        case HedgehogScreenChoices.Modify:
                            EditHedgehogMain();
                            Console.ReadLine();
                            break;

                        case HedgehogScreenChoices.Exit:
                            ScreenDefinionService.Show("HedgehogsScreen.json", 7);
                            Console.ReadLine();
                            return;
                    }
                }
                catch
                {
                    ScreenDefinionService.Show("HedgehogsScreen.json", 8);
                    Console.ReadLine();
                }
            }
        }

        #endregion // Public Methods

        #region Private Methods

        /// <summary>
        /// List all hedgehog's.
        /// </summary>
        private void ListHedgehog()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Hedgehogs is not null &&
                _dataService.Animals.Mammals.Hedgehogs.Count > 0)
            {
                ScreenDefinionService.Show("HedgehogsScreen.json", 9);
                int i = 1;
                foreach (Hedgehog hedgehog in _dataService.Animals.Mammals.Hedgehogs)
                {
                    ScreenDefinionService.Show("HedgehogsScreen.json", 10, i.ToString());
                    hedgehog.Display();
                    i++;
                }
            }
            else
            {
                ScreenDefinionService.Show("HedgehogsScreen.json", 11);
            }
        }

        /// <summary>
        /// Add a hedgehog.
        /// </summary>
        private void AddHedgehog()
        {
            try
            {
                Hedgehog hedgehog = AddEditHedgehog();
                _dataService?.Animals?.Mammals?.Hedgehogs?.Add(hedgehog);
                ScreenDefinionService.Show("HedgehogsScreen.json", 12, hedgehog.Name);
            }
            catch
            {
                ScreenDefinionService.Show("HedgehogsScreen.json", 13);
            }
        }

        /// <summary>
        /// Deletes a hedgehog.
        /// </summary>
        private void DeleteHedgehog()
        {
            try
            {
                ScreenDefinionService.Show("HedgehogsScreen.json", 14);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Hedgehog? hedgehog = (Hedgehog?)(_dataService?.Animals?.Mammals?.Hedgehogs
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (hedgehog is not null)
                {
                    _dataService?.Animals?.Mammals?.Hedgehogs?.Remove(hedgehog);
                    ScreenDefinionService.Show("HedgehogsScreen.json", 15, hedgehog.Name);
                }
                else
                {
                    ScreenDefinionService.Show("HedgehogsScreen.json", 16);
                }
            }
            catch
            {
                ScreenDefinionService.Show("HedgehogsScreen.json", 17);
            }
        }

        /// <summary>
        /// Edits an existing hedgehog after choice made.
        /// </summary>
        private void EditHedgehogMain()
        {
            try
            {
                ScreenDefinionService.Show("HedgehogsScreen.json", 18);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Hedgehog? hedgehog = (Hedgehog?)(_dataService?.Animals?.Mammals?.Hedgehogs?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (hedgehog is not null)
                {
                    Hedgehog hedgehogEdited = AddEditHedgehog();
                    hedgehog.Copy(hedgehogEdited);
                    ScreenDefinionService.Show("HedgehogsScreen.json", 19);
                    hedgehog.Display();
                }
                else
                {
                    ScreenDefinionService.Show("HedgehogsScreen.json", 20);
                }
            }
            catch
            {
                ScreenDefinionService.Show("HedgehogsScreen.json", 21);
            }
        }

        /// <summary>
        /// Adds/edit specific hedgehog.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Hedgehog AddEditHedgehog()
        {
            ScreenDefinionService.Show("HedgehogsScreen.json", 22);
            string? name = Console.ReadLine();
            ScreenDefinionService.Show("HedgehogsScreen.json", 23);
            string? ageAsString = Console.ReadLine();
            ScreenDefinionService.Show("HedgehogsScreen.json", 24);
            string? color = Console.ReadLine();
            ScreenDefinionService.Show("HedgehogsScreen.json", 25);
            string? spikeLengthAsString = Console.ReadLine();
            ScreenDefinionService.Show("HedgehogsScreen.json", 26);
            string? favoriteFood = Console.ReadLine();

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
            if (spikeLengthAsString is null)
            {
                throw new ArgumentNullException(nameof(spikeLengthAsString));
            }
            if (favoriteFood is null)
            {
                throw new ArgumentNullException(nameof(favoriteFood));
            }
            int age = int.Parse(ageAsString);
            int spikeLength = int.Parse(spikeLengthAsString);
            Hedgehog hedgehog = new Hedgehog(name, age, color, spikeLength, favoriteFood);
            return hedgehog;
        }

        #endregion // Private Methods
    }
}
