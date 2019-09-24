using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using ThomasExpressProducer.Configuration;
using ThomasExpressProducer.Data.Context;
using ThomasExpressProducer.Data.Entity;
using ThomasExpressProducer.Data.Interfaces;
using ThomasExpressProducer.Data.Repository;

namespace ThomasExpressProducer
{
    public class ThomasExpressProducerService
    {
        private readonly ILogger _log;
        private readonly Timer executionTimer = new Timer();
        private static readonly string ThomasExpressConnectionId = "ThomasExpress";

        private static readonly string dbConnectionThomasExpress = AppSettings.Settings.ConnectionSettings.FirstOrDefault(db => db.Id == ThomasExpressConnectionId).ConnectionString;

        private readonly IThomasExpressContext _thomasExpressContext;
        private readonly ILocomotivaRepository _locomotivaRepository;
        private readonly ITrainRepository _trainRepository;
        private readonly IWagonRepository _wagonRepository;
        private readonly IStationRepository _stationRepository;
        private readonly ITerminalRepository _terminalRepository;

        public ThomasExpressProducerService(ILogger log)
        {
            _log = log;
            _thomasExpressContext = new ThomasExpressContext(log, dbConnectionThomasExpress);
            _locomotivaRepository = new LocomotivaRepository(_thomasExpressContext);
            _trainRepository = new TrainRepository(_thomasExpressContext);
            _wagonRepository = new WagonRepository(_thomasExpressContext);
            _stationRepository = new StationRepository(_thomasExpressContext);
            _terminalRepository = new TerminalRepository(_thomasExpressContext);
        }

        public void Start()
        {
            _log.Information("Service Starting...");

            var executionFrequency = AppSettings.Settings.ApplicationSettings.ExecutionFrequency;
            executionTimer.Interval = TimeSpan.FromSeconds(executionFrequency).TotalMilliseconds;
            executionTimer.Elapsed += async (sender, e) =>
            {
                await ExecuteAsync();
            };

            executionTimer.AutoReset = false;
            executionTimer.Start();

            _log.Information("Service Started");
        }

        public void Stop()
        {

        }

        private async Task ExecuteAsync()
        {
            _log.Information("Start retrieving database data");

            _log.Information("Retrieving locomotives");
            List<Locomotive> locomotives = _locomotivaRepository.GetLocomotives();
            _log.Information("Locomotives successfully retrieved");

            _log.Information("Retrieving wagons");
            List<Wagon> wagons = _wagonRepository.GetWagons();
            _log.Information("Wagons successfully retrieved");

            _log.Information("Retrieving stations");
            List<Station> stations = _stationRepository.GetStations();
            _log.Information("Stations successfully retrieved");

            _log.Information("Retrieving terminals");
            List<Terminal> terminals = _terminalRepository.GetTerminals();
            _log.Information("Terminals successfully retrieved");

            _log.Information("End retrieving database data");

            var randomLocomotive = SortLocomotive(locomotives);
            var randomWagons = SortWagons(wagons);
            var quantities = EnumerateWagons(randomWagons, randomLocomotive.TractiveEffort);
        }

        private Dictionary<Wagon, int> EnumerateWagons(List<Wagon> randomWagons, int tractiveEffort)
        {

            throw new NotImplementedException();
        }

        private Locomotive SortLocomotive(List<Locomotive> locomotives)
        {
            var locomotiveNumber = RandomValue(locomotives.Count);

            return locomotives[locomotiveNumber];
        }

        private List<Wagon> SortWagons(List<Wagon> wagons)
        {
            int countWagons = wagons.Count;
            int randomValue = RandomValue(countWagons);
            int quantityOfDifferentWagons = randomValue == 0 ? 1 : randomValue;

            List<Wagon> selectedWagons = new List<Wagon>();

            for (var i = 0; i < quantityOfDifferentWagons; i++)
            {
                var wagonNumber = RandomValue(countWagons);
                var randomWagon = wagons[wagonNumber];

                selectedWagons.Add(randomWagon);
                wagons.Remove(randomWagon);
            }

            return selectedWagons;
        }

        private int RandomValue(int count)
        {
            Random rand = new Random();

            return rand.Next(0, count);
        }
    }
}
