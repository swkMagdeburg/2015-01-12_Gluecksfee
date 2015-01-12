using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using GalaSoft.MvvmLight.Command;

namespace Gluecksfee.Core
{
    public class ErmittleGewinnerViewModel
    {
        private readonly ISpielerRepository _spielerRepository;
        private readonly Random _zufallsgenerator;

        public ErmittleGewinnerViewModel(ISpielerRepository spielerRepository)
        {
            _spielerRepository = spielerRepository;
            _zufallsgenerator = new Random();

            Spiele = new ObservableCollection<Spiel>();
            LoseSpieleAus = new RelayCommand(LoseSpieleAusExecute, LoseSpieleAusCanExecute);
            SimuliereSpiele = new RelayCommand(SimuliereSpieleExecute, SimuliereSpieleCanExecute);
            EntferneVerlierer = new RelayCommand(EntferneVerliererExecute, EntferneVerliererCanExecute);
        }

        public Spieler Gewinner { get; private set; }
        public ObservableCollection<Spiel> Spiele { get; private set; }
        public ICommand LoseSpieleAus { get; private set; }
        public ICommand SimuliereSpiele { get; private set; }
        public ICommand EntferneVerlierer { get; private set; }

        public IEnumerable<Spieler> Spieler
        {
            get { return _spielerRepository.Spieler; }
        }

        private void LoseSpieleAusExecute()
        {
            Spiele.Clear();

            var lostopf = _spielerRepository.Spieler.ToList();

            while (lostopf.Any())
            {
                var index = _zufallsgenerator.Next(lostopf.Count);
                var heimSpieler = lostopf.ElementAt(index);
                lostopf.RemoveAt(index);

                if (lostopf.Any())
                {
                    index = _zufallsgenerator.Next(lostopf.Count);
                    var gastSpieler = lostopf.ElementAt(index);
                    lostopf.RemoveAt(index);
                    Spiele.Add(new Spiel(heimSpieler, gastSpieler));
                }
                else
                {
                    Spiele.Add(new Spiel(heimSpieler, new Spieler("Dummy", "Spieler")));
                }
            }
        }

        private bool LoseSpieleAusCanExecute()
        {
            return _spielerRepository.Spieler.Count() >= 2;
        }

        private void SimuliereSpieleExecute()
        {
            foreach (var spiel in Spiele)
            {
                if (_zufallsgenerator.Next(2) == 0)
                {
                    spiel.SetzeGewinnerAufHeimspieler();
                }
                else
                {
                    spiel.SetzeGewinnerAufGastspieler();
                }
            }
        }

        private bool SimuliereSpieleCanExecute()
        {
            return Spiele.Any();
        }

        private void EntferneVerliererExecute()
        {
            foreach (var spiel in Spiele)
            {
                _spielerRepository.Entferne(spiel.Verlierer);
            }

            if (_spielerRepository.Spieler.Count() == 1)
            {
                Gewinner = _spielerRepository.Spieler.First();
            }
        }

        private bool EntferneVerliererCanExecute()
        {
            return Spiele.Any(s => s.Gewinner != null);
        }
    }
}