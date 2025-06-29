Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Iniciando Sistema de Gerenciamento de Hospedagem...");

HospedeRepository hospedeRepository = new HospedeRepository();
SuiteRepository suiteRepository = new SuiteRepository();
ReservaService reservaService = new ReservaService(suiteRepository);

hospedeRepository.AdicionarHospede(new Hospede("Alice", "Smith"));
hospedeRepository.AdicionarHospede(new Hospede("Bob", "Johnson"));