using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VE2C5T_HFT_2021221.Models;

namespace VE2C5T_GUI_2021222.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Pet> Pets { get; set; }
        public ICommand CreatePetCommand { get; set; }
        public ICommand DeletePetCommand { get; set; }
        public ICommand UpdatePetCommand { get; set; }

        private Pet selectedPet;

        public Pet SelectedPet
        {
            get { return selectedPet; }
            set {
                if (value != null){
                    selectedPet = new Pet(value.Name, value.Species,
                        value.Weight, value.Age, value.MonthlyCostInHUF,
                        value.PetOwnerId, value.VetId);
                    selectedPet.Id = value.Id;
                }
                OnPropertyChanged();
                (DeletePetCommand as RelayCommand).NotifyCanExecuteChanged();
                (AVGAgeBySpeciesCommand as RelayCommand).NotifyCanExecuteChanged();
                (AVGWeightBySpeciesCommand as RelayCommand).NotifyCanExecuteChanged();
                (AVGCostBySpeciesCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public RestCollection<Vet> Vets { get; set; }
        private Vet selectedVet;
        public Vet SelectedVet
        {
            get { return selectedVet; }
            set 
            {
                if (value != null){
                    selectedVet = new Vet(value.Name, value.PhoneNumber, value.SalaryInHUF, value.Age);
                    selectedVet.Id = value.Id;
                }
                OnPropertyChanged();
                (DeleteVetCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public ICommand CreateVetCommand { get; set; }
        public ICommand DeleteVetCommand { get; set; }
        public ICommand UpdateVetCommand { get; set; }



        public RestCollection<PetOwner> PetOwners { get; set; }
        private PetOwner selectedPetOwner;

        public PetOwner SelectedPetOwner
        {
            get { return selectedPetOwner; }
            set
            {
                if (value != null)
                {
                    selectedPetOwner = new PetOwner(value.Name, value.PhoneNumber, value.Age, value.SalaryInHUF);
                    selectedPetOwner.Id = value.Id;
                }
                OnPropertyChanged();
                (DeletePetOwnerCommand as RelayCommand).NotifyCanExecuteChanged();
                
            }
        }
        public ICommand CreatePetOwnerCommand { get; set; }
        public ICommand DeletePetOwnerCommand { get; set; }
        public ICommand UpdatePetOwnerCommand { get; set; }



        RestService rest;
        public ICommand AVGAgeBySpeciesCommand { get; set; }

        public ICommand AVGWeightBySpeciesCommand { get; set; }
        public ICommand AVGCostBySpeciesCommand { get; set; }

        public MainWindowViewModel()
        {
            
            if (!IsInDesignMode){
                Pets = new RestCollection<Pet>("http://localhost:60557/", "pet", "hub");
                Vets = new RestCollection<Vet>("http://localhost:60557/", "vet", "hub");
                PetOwners = new RestCollection<PetOwner>("http://localhost:60557/", "petowner", "hub");
                
                rest = new RestService("http://localhost:60557/");

                CreatePetCommand = new RelayCommand(() => {
                    Pets.Add(new Pet(SelectedPet.Name, SelectedPet.Species, SelectedPet.Weight,
                        SelectedPet.Age, SelectedPet.MonthlyCostInHUF,
                        SelectedPet.PetOwnerId, SelectedPet.VetId));
                });

                DeletePetCommand = new RelayCommand(() => {
                    Pets.Delete(SelectedPet.Id);
                }, () => {
                    return SelectedPet != null;
                });

                UpdatePetCommand = new RelayCommand(() => {
                    Pets.Update(SelectedPet); 
                });

                AVGAgeBySpeciesCommand = new RelayCommand(() => {
                    var q = rest.Get<KeyValuePair<string, int>>("stat/GrupPetsBySpeciesAndTheirAVGage").ToList();
                    string result = "";
                    foreach (var item in q){
                        result += $"Faj: {item.Key.ToString()}\n\tAVG Age: {item.Value.ToString()}\n";
                    }
                    MessageBox.Show(result);
                });
                AVGWeightBySpeciesCommand = new RelayCommand(() => {
                    var q = rest.Get<KeyValuePair<string, int>>("stat/GrupPetsBySpeciesAndTheirAVGweight").ToList();
                    string result = "";
                    foreach (var item in q){
                        result += $"Faj: {item.Key.ToString()}\n\tAVG Weight: {item.Value.ToString()}\n";
                    }
                    MessageBox.Show(result);
                });
                AVGCostBySpeciesCommand = new RelayCommand(() => {
                    var q = rest.Get<KeyValuePair<string, int>>("stat/GrupPetsBySpeciesAndTheirAVGcost").ToList();
                    string result = "";
                    foreach (var item in q){
                        result += $"Faj: {item.Key.ToString()}\n\tAVG Weight: {item.Value.ToString()}\n";
                    }
                    MessageBox.Show(result);
                });


                CreateVetCommand = new RelayCommand( () => {
                    Vet v = new Vet(SelectedVet.Name, SelectedVet.PhoneNumber, SelectedVet.SalaryInHUF, SelectedVet.Age);
                    Vets.Add(v);
                });


                DeleteVetCommand = new RelayCommand(() => {
                    Vets.Delete(SelectedVet.Id);
                }, () => {
                    return SelectedVet != null;
                });

                UpdateVetCommand = new RelayCommand(() => {
                    Vets.Update(SelectedVet);
                });

                CreatePetOwnerCommand = new RelayCommand(() => {
                    PetOwner po = new PetOwner(SelectedPetOwner.Name, SelectedPetOwner.PhoneNumber, SelectedPetOwner.Age, SelectedPetOwner.SalaryInHUF);
                    PetOwners.Add(po);
                });

                DeletePetOwnerCommand = new RelayCommand(() => {
                    PetOwners.Delete(SelectedPetOwner.Id);
                }, () => {
                    return SelectedPetOwner != null;
                });

                UpdatePetOwnerCommand = new RelayCommand(() => {
                    PetOwners.Update(SelectedPetOwner);
                });


                SelectedPet = new Pet();
                SelectedVet = new Vet();
                SelectedPetOwner = new PetOwner();

                
            }
          
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


    }
}
