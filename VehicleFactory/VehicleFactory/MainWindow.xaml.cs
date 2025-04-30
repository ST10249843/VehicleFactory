using System;
using System.Windows;
using System.Windows.Controls;

namespace VehicleFactoryWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void VehicleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EngineComboBox.Items.Clear();
            var selectedItem = VehicleComboBox.SelectedItem as ComboBoxItem;
            if (selectedItem == null) return;

            string vehicle = selectedItem.Content.ToString();

            if (vehicle == "Car")
            {
                EngineComboBox.Items.Add("Gasoline");
                EngineComboBox.Items.Add("Electric");
                EngineComboBox.Items.Add("Hybrid");
            }
            else if (vehicle == "Motorcycle")
            {
                EngineComboBox.Items.Add("Gasoline");
            }
            else if (vehicle == "Truck")
            {
                EngineComboBox.Items.Add("Gasoline");
            }
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedVehicle = VehicleComboBox.SelectedItem as ComboBoxItem;
            var selectedEngine = EngineComboBox.SelectedItem as string;

            if (selectedVehicle == null || string.IsNullOrWhiteSpace(selectedEngine))
            {
                ResultTextBlock.Text = "Please select both vehicle and engine types.";
                return;
            }

            string vehicleType = selectedVehicle.Content.ToString();

            try
            {
                IVehicle orderedVehicle = VehicleFactory.CreateVehicle(vehicleType, selectedEngine);
                ResultTextBlock.Text = $"ORDER OF ({orderedVehicle.Type}, {orderedVehicle.Engine.EngineType}) CONFIRMED";
            }
            catch (Exception ex)
            {
                ResultTextBlock.Text = $"Error: {ex.Message}";
            }
        }
    }

    // Interfaces and Classes
    public interface IVehicle
    {
        string Type { get; }
        IEngine Engine { get; set; }
    }

    public interface IEngine
    {
        string EngineType { get; }
    }

    public class ElectricEngine : IEngine
    {
        public string EngineType
        {
            get { return "Electric"; }
        }
    }

    public class GasolineEngine : IEngine
    {
        public string EngineType
        {
            get { return "Gasoline"; }
        }
    }

    public class HybridEngine : IEngine
    {
        public string EngineType
        {
            get { return "Hybrid"; }
        }
    }

    // Abstract Engine Factories
    public interface IEngineFactory
    {
        IEngine GetEngine(string type);
    }

    public class CarEngineFactory : IEngineFactory
    {
        public IEngine GetEngine(string type)
        {
            if (type == "Gasoline") return new GasolineEngine();
            if (type == "Hybrid") return new HybridEngine();
            if (type == "Electric") return new ElectricEngine();
            throw new ArgumentException("Invalid engine for Car");
        }
    }

    public class MotorcycleEngineFactory : IEngineFactory
    {
        public IEngine GetEngine(string type)
        {
            if (type == "Gasoline") return new GasolineEngine();
            throw new ArgumentException("Invalid engine for Motorcycle");
        }
    }

    public class TruckEngineFactory : IEngineFactory
    {
        public IEngine GetEngine(string type)
        {
            if (type == "Gasoline") return new GasolineEngine();
            throw new ArgumentException("Invalid engine for Truck");
        }
    }

    public class Car : IVehicle
    {
        public string Type
        {
            get { return "Car"; }
        }

        public IEngine Engine { get; set; }
    }

    public class Motorcycle : IVehicle
    {
        public string Type
        {
            get { return "Motorcycle"; }
        }

        public IEngine Engine { get; set; }
    }

    public class Truck : IVehicle
    {
        public string Type
        {
            get { return "Truck"; }
        }

        public IEngine Engine { get; set; }
    }

    public static class VehicleFactory
    {
        public static IVehicle CreateVehicle(string vehicleType, string engineType)
        {
            IVehicle vehicle = null;
            IEngineFactory engineFactory = null;

            if (vehicleType == "Car")
            {
                vehicle = new Car();
                engineFactory = new CarEngineFactory();
            }
            else if (vehicleType == "Motorcycle")
            {
                vehicle = new Motorcycle();
                engineFactory = new MotorcycleEngineFactory();
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck();
                engineFactory = new TruckEngineFactory();
            }
            else
            {
                throw new ArgumentException("Invalid vehicle type");
            }

            vehicle.Engine = engineFactory.GetEngine(engineType);
            return vehicle;
        }
    }
}
