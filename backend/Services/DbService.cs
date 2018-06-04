using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using MasyvaiPrasidedaVienetu.DAL;
using MasyvaiPrasidedaVienetu.Interfaces;
using MasyvaiPrasidedaVienetu.Logging;
using Services.Attributes;

namespace MasyvaiPrasidedaVienetu.Services
{
    [MethodLogger]
    public class DbService : IDbService
    {
        private UserRepository _userRepository;
        private ItemRepository _itemRepository;
        private CategoryRepository _categoryRepository;
        private OrderRepository _orderRepository;
        private ILogger _logger;

        public DbService()
        {
            var ctx = new ArrayStartAtOneCtxContainer();
            _userRepository = new UserRepository(ctx);
            _itemRepository = new ItemRepository(ctx);
            _categoryRepository = new CategoryRepository(ctx);
            _orderRepository = new OrderRepository(ctx);
        }

        public async Task RunDatabaseSeed()
        {
            try
            {
                //Users
                {
                    User user1 = new User
                    {
                        Email = "Vartotojas1@test.lt",
                        City = "Vilnius",
                        FirstName = "Vartotojas1",
                        IsBanned = false,
                        PasswordHash = "slaptazodis1",
                        UserRole = 0,
                        Zip = "LT-00000",
                        Street = "Gatve",
                        SecondName = "Pavarde1",
                        HouseNumber = "4",
                        PhoneNumber = "37010123453"
                    };
                    await _userRepository.AddAsync(user1);
                }
                {
                    User user2 = new User
                    {
                        Email = "Vartotojas2@test.lt",
                        City = "Vilnius",
                        FirstName = "Vartotojas2",
                        IsBanned = false,
                        PasswordHash = "slaptazodis2",
                        UserRole = 0,
                        Zip = "LT-00000",
                        Street = "Gatve",
                        SecondName = "Pavarde2",
                        HouseNumber = "4",
                        PhoneNumber = "37010123453"
                    };
                    await _userRepository.AddAsync(user2);
                }
                {
                    User user3 = new User
                    {
                        Email = "Vartotojas3@test.lt",
                        City = "Vilnius",
                        FirstName = "Vartotojas3",
                        IsBanned = true,
                        PasswordHash = "slaptazodis3",
                        UserRole = 0,
                        Zip = "LT-00000",
                        Street = "Gatve",
                        SecondName = "Pavarde3",
                        HouseNumber = "4",
                        PhoneNumber = "37010123453"
                    };
                    await _userRepository.AddAsync(user3);
                }
                //Items
                {
                    Item item1 = new Item
                    {
                        Name = "Choke Logo Series Pinky",
                        Images = new[] { new Image() { ImageUrl = "http://terrasport.lt/10875-thickbox_default/riedlente-choke-logo-series-pinky.jpg" } },
                        Price = 49,
                        Description = "Riedlentė Choke Logo Series Pinky, skirta pradedantiesiems ir pažengusiems riedlentininkams. Tinkama klasikiniam stiliui, važinėjimui mieste ir nesudėtingiems triukams. Riedlentė pagaminta iš aukštos kokybės medžiagų, tai lemia puikų jos kontroliavimą. Gamintojo nurodomas maksimalus apkrovos indeksas - 100kg.",
                        Categories = new[] { new Category() { Name = "Skateboards" } },
                        Property = new Properties() { Ilgis = "31\"", Plotis = "7.5\"", Ratai = "52x30mm, 100A", Guoliai = "Wicked ABEC 5", Asys = "5\"Temple Pro", Spalva = "Oranžinė" },
                        SkuCode = "SK75623"
                    };
                    await _itemRepository.AddAsync(item1);
                }
                {
                    Item item2 = new Item
                    {
                        Name = "Choke Skull Series Homegrown Evo",
                        Images = new[] { new Image() { ImageUrl = "http://terrasport.lt/9140-thickbox_default/riedlente-choke-skull-series-homegrown-evo.jpg " } },
                        Price = 59,
                        Description = "Riedlentė Choke Skull Series Homegrown Evo, skirta pradedantiesiems ir pažengusiems riedlentininkams. Tinkama klasikiniam stiliui,važinėjimui mieste ir nesudėtingiems triukams. Riedlentė pagaminta iš aukštos kokybės medžiagų, tai lemia puikų jos kontroliavimą. Gamintojo nurodomas maksimali apkrovos indeksas - 100kg.",
                        Categories = new[] { await _categoryRepository.FindByName("Skateboards") },
                        Property = new Properties() { Ilgis = "31\"", Plotis = "8\"", Ratai = "52x33mm, 100A", Guoliai = "Wicked ABEC 7", Asys = "5\"Temple Pro", Spalva = "Mėlyna" },
                        SkuCode = "SK564523"
                    };
                    await _itemRepository.AddAsync(item2);
                }
                {
                    Item item3 = new Item
                    {
                        Name = "Choke Heavy Metal Silver",
                        Images = new[] { new Image() { ImageUrl = "http://terrasport.lt/10755-thickbox_default/riedlente-choke-heavy-metal-silver.jpg" }, new Image() { ImageUrl = "http://terrasport.lt/10756-thickbox_default/riedlente-choke-heavy-metal-silver.jpg" } },
                        Price = 59,
                        Description = "Riedlentė Choke Heavy Metal Silver, skirta pažengusiems riedlentininkams. Tinkama klasikiniam stiliui ir triukams. Riedlentė pagaminta iš aukštos kokybės medžiagų, tai lemia puikų jos kontroliavimą. Gamintojo nurodomas maksimali apkrovos indeksas - 100kg.",
                        Categories = new[] { await _categoryRepository.FindByName("Skateboards") },
                        Property = new Properties() { Ilgis = "32\"", Plotis = "8\"", Ratai = "32x30mm, 100A", Guoliai = "Wicked ABEC 7", Asys = "5\"gravity casted AL", Spalva = "Sidabrinė" },
                        SkuCode = "SK951236"
                    };
                    await _itemRepository.AddAsync(item3);
                }
                {
                    Item item4 = new Item
                    {
                        Name = "Mindless Voodoo Cayuga II",
                        Images = new[] { new Image() { ImageUrl = "http://www.vejobroliai.lt/3721-large_default/mindless-voodoo-cayuga-ii.jpg" }, new Image() { ImageUrl = "http://www.vejobroliai.lt/3723-large_default/mindless-voodoo-cayuga-ii.jpg" }, new Image() { ImageUrl = "http://www.vejobroliai.lt/3724-large_default/mindless-voodoo-cayuga-ii.jpg" } },
                        Price = 195,
                        Description = "Mindless Cayuga Longboard- kokybės, greičio, komforto derinys.Tai lenta, su kuria pasijusite tarsi skriedami banglente jūros bangomis.Neužmirškite apsaugų - ši lenta įsibėgėja labai greitai.Išpjovos važiuoklei ir ratams gerokai pažemino šio asfalto bolido svorio centrą, tad ja galima užtikrintai ir tiksliai manevruoti posūkiuose(carving) bei stabiliai laikytis lekiant dideliu greičiu nuokalne(downhill).",
                        Categories = new[] { new Category() { Name = "Longboards" } },
                        Property = new Properties() { Ilgis = "39\"", Plotis = "10\"", Ratai = "75x52mm, 78A", Guoliai = "High precision Mindless", MaksimalusSvoris = "130kg" },
                        SkuCode = "SK965424"
                    };
                    await _itemRepository.AddAsync(item4);
                }
                {
                    Item item5 = new Item
                    {
                        Name = "Mindless Voodoo Lakota DT",
                        Images = new[] { new Image() { ImageUrl = "http://www.vejobroliai.lt/3673-thickbox_default/mindless-voodoo-lakota-dt-.jpg" }, new Image() { ImageUrl = "http://www.vejobroliai.lt/3246-thickbox_default/mindless-voodoo-lakota-dt-.jpg" }, new Image() { ImageUrl = "http://www.vejobroliai.lt/3672-thickbox_default/mindless-voodoo-lakota-dt-.jpg" } },
                        Price = 171.27,
                        Description = "Mindless Maverick DT (drop through) Longboard- kokybės, greičio, komforto derinys. Ištisinė Kanados klevo (drop through) formos lenta paruošta važiavimui. Tai lenta, su kuria pasijusite tarsi čiuoždami banglente jūros bangomis.Su ja galima užtikrintai ir tiksliai manevruoti posūkiuose(carving) bei stabiliai laikytis lekiant dideliu greičiu nuokalne(downhill) Neužmirškite apsaugų - ši lenta įsibėgėja labai greitai!",
                        Categories = new[] { await _categoryRepository.FindByName("Longboards") },
                        Property = new Properties() { Ilgis = "40\"", Plotis = "29.75\"", Guoliai = "High precision Mindless", MaksimalusSvoris = "130kg" },
                        SkuCode = "SK321785"
                    };
                    await _itemRepository.AddAsync(item5);
                }
                {
                    Item item6 = new Item
                    {
                        Name = "Surf Logic Fuck The Rules",
                        Images = new[] { new Image() { ImageUrl = "http://www.vejobroliai.lt/3933-thickbox_default/fuck-the-rules.jpg" }, new Image() { ImageUrl = "http://www.vejobroliai.lt/3932-thickbox_default/fuck-the-rules.jpg" } },
                        Price = 139,
                        Description = "Šių metų Surf Logic kolekcijos \"free ride\" longboardas Fuck The Rules – pats tas prasilėkti mieste ar parke. Lenkia visus atitinkamos klasės longbordus savo kategorijoje.",
                        Categories = new[] { await _categoryRepository.FindByName("Longboards") },
                        Property = new Properties() { Ilgis = "40,5\"", Plotis = "9.75\"", Ratai = "71x51 82A", Guoliai = "ABEC 7", MaksimalusSvoris = "120kg" },
                        SkuCode = "SK862314"
                    };
                    await _itemRepository.AddAsync(item6);
                }
                {
                    Item item7 = new Item
                    {
                        Name = "Tempish Flow 46",
                        Images = new[] { new Image() { ImageUrl = "http://terrasport.lt/10621-thickbox_default/longboard-as-tempish-flow-46.jpg " }, new Image() { ImageUrl = "http://terrasport.lt/10622-thickbox_default/longboard-as-tempish-flow-46.jpg" }, new Image() { ImageUrl = "http://terrasport.lt/10623-thickbox_default/longboard-as-tempish-flow-46.jpg" }, new Image() { ImageUrl = "http://terrasport.lt/10624-thickbox_default/longboard-as-tempish-flow-46.jpg" } },
                        Price = 155.86,
                        Description = "Longboardas Tempish Flow 46. Didesnė ir platesnė nei standartinė riedlentė suteikia papildomo stabilumo ir komforto, todėl ja lengviau išmoks važiuoti net ir pradedantysis. Šis klasikinio lašo formos modelis yra itin universalus ir yra tinkamas kuo įvairiausiomis sąlygomis. Du bambuko sluoksniai šią riedlentę padaro itin lanksčia ir lengva.",
                        Categories = new[] { await _categoryRepository.FindByName("Longboards") },
                        Property = new Properties() { Ilgis = "46\"", Plotis = "9.6\"", Ratai = "70x51 78A", Guoliai = "ABEC 9", MaksimalusSvoris = "100kg" },
                        SkuCode = "SK452354"
                    };

                    await _itemRepository.AddAsync(item7);
                }
                {
                    Item item8 = new Item
                    {
                        Name = "Volten Imperio II Dropthrough",
                        Images = new[] { new Image() { ImageUrl = "http://terrasport.lt/9258-thickbox_default/longboard-as-volten-imperio-ii-dropthrough.jpg" }, new Image() { ImageUrl = "http://terrasport.lt/9257-thickbox_default/longboard-as-volten-imperio-ii-dropthrough.jpg" }, new Image() { ImageUrl = "http://terrasport.lt/9259-thickbox_default/longboard-as-volten-imperio-ii-dropthrough.jpg" } },
                        Price = 158.26,
                        Description = "Ilgoji riedlentė Volten Imperio II Dropthrough, skirta pradedantiesiems ir pažengusiems riedlentininkams, kurie mėgsta važinėti su longboard tipo riedlentėmis. Lentos ilgio pagalba jaučiamas komfotas tiek važiuojant lygia vieta, tiek nuokalne. Riedlentės plotis suteikia papildomo stabilumo. Riedlentė pagaminta iš aukštos kokybės medžiagų.",
                        Categories = new[] { await _categoryRepository.FindByName("Longboards") },
                        Property = new Properties() { Ilgis = "38\"", Plotis = "9\"", Ratai = "70x51 78A", Guoliai = "ABEC 9", MaksimalusSvoris = "100kg" },
                        SkuCode = "SK367845"
                    };
                    await _itemRepository.AddAsync(item8);
                }
                {
                    Item item9 = new Item
                    {
                        Name = "SEBA FR1 80 Grey",
                        Images = new[] { new Image() { ImageUrl = "http://www.vejobroliai.lt/3687-thickbox_default/seba-fr1-80-grey-rieduciai.jpg" }, new Image() { ImageUrl = "http://www.vejobroliai.lt/3686-thickbox_default/seba-fr1-80-grey-rieduciai.jpg" } },
                        Price = 176.22,
                        Description = "SEBA FR1 80 slalomo freestyle gatvės riedučiai- vienas populiariausių modelių pasaulyje. Keičiamos šoninės apsauginės-abrazyvinės plokštelės, apsaugančios batą nuo subraižymų mokinantis slydimus. Patentuotas auliuko 4 pozicijų nustatymas.",
                        Categories = new[] { new Category() { Name = "Riedučiai" } },
                        Property = new Properties() { Guoliai = "Twincam Titalium freeride", Asys = "8mm", Ratai = "80mm 84A", Paskirtis = "Freeride" },
                        SkuCode = "SK235487"
                    };
                    await _itemRepository.AddAsync(item9);
                }
                {
                    Item item10 = new Item
                    {
                        Name = "Powerslide Kaze SC 110",
                        Images = new[] { new Image() { ImageUrl = "http://terrasport.lt/10763-thickbox_default/powerslide-kaze-sc-110-rieduciai.jpg " }, new Image() { ImageUrl = "http://terrasport.lt/10764-thickbox_default/powerslide-kaze-sc-110-rieduciai.jpg" }, new Image() { ImageUrl = "http://terrasport.lt/10765-thickbox_default/powerslide-kaze-sc-110-rieduciai.jpg" } },
                        Price = 299,
                        Discount = 0.2,
                        Description = "Lengvas ir inovatyvus Powerslide riedučių modelis Kaze SC 110. Šiuose riedučiuose sumontuota naujoji Trinity sistema, dėl kurios svorio centras atsiduria žemiau, o pats riedutis tampa stabilesnis dėl trijuose taškuose tvirtinamo rėmo. Batas yra itin tvirtas, bet tuo pačiu metu ir lengvas, dėl to šis modelis tinka tiek važinėjimui mieste, tiek ilgesnėm distancijom.",
                        Categories = new[] { await _categoryRepository.FindByName("Riedučiai") },
                        Property = new Properties() { Guoliai = "Wicked freespin ABEC 9", Asys = "8mm", Ratai = "110mm 88A", Paskirtis = "Fitness" },
                        SkuCode = "SK198752"
                    };
                    await _itemRepository.AddAsync(item10);
                }
                {
                    Item item11 = new Item
                    {
                        Name = "SEBA FR2 80",
                        Images = new[] { new Image() { ImageUrl = "http://www.vejobroliai.lt/3197-thickbox_default/seba-fr2-80-rieduciai.jpg" } },
                        Price = 158.4,
                        Discount = 20,
                        Description = "Seba FR2 80 sukurti žengti į SEBA freestyle riedučių pasaulį. Gaminant FRX buvo naudojama populiariojo FR1 bazė- bato kevalas ir rėmas, tad daugeliu charakteristikų šis modelis pasižymi FR1 savybėmis.",
                        Categories = new[] { await _categoryRepository.FindByName("Riedučiai") },
                        Property = new Properties() { Ratai = "80mm 85A", Paskirtis = "Freeride" },
                        SkuCode = "SK987652"
                    };
                    await _itemRepository.AddAsync(item11);
                }
                {
                    Item item12 = new Item
                    {
                        Name = "SEBA PRO pack 3 S",
                        Images = new[] { new Image() { ImageUrl = "http://www.vejobroliai.lt/3698-thickbox_default/seba-apsaugu-komplektas-pro-pack-3.jpg" }, new Image() { ImageUrl = "http://www.vejobroliai.lt/3697-thickbox_default/seba-apsaugu-komplektas-pro-pack-3.jpg" } },
                        Price = 60.39,
                        Description = "Kokybiškos ir tvirtos riešų, kelių ir alkūnių apsaugos visiems riedutininkams, lentų sportininkams ir ne tik. Kelių ir alkūnių apsaugos.Plastikinė apsauginė plokštelė.Minkšta CoolMax medžiaga iš vidaus.Tvirtinimas - elastingi Velcro dirželiai, kuriuos galima užfiksuoti ir nenusiimant riedučių dėl easy on / easy off sistemos.Tinklinė medžiaga apsaugo vidinę kelio pusę nuo prakaitavimo. Riešų apsaugos.Plastikinis nuimamas riešo įtvirtinimas.Vidinė medžiaga su CoolMax technologija, dėl ko rankos neprakaituoja.Greita ir patogi tvirtinimo sistema.Pirmo lygio apsauga.",
                        Categories = new[] { new Category() { Name = "Apsaugos" } },
                        Property = new Properties() { Gamintojas = "SEBA", Dydis = "S" },
                        SkuCode = "SK875622"
                    };
                    await _itemRepository.AddAsync(item12);
                }
                {
                    Item item13 = new Item
                    {
                        Name = "SEBA PRO pack 3 L",
                        Images = new[] { new Image() { ImageUrl = "http://www.vejobroliai.lt/3698-thickbox_default/seba-apsaugu-komplektas-pro-pack-3.jpg" }, new Image() { ImageUrl = "http://www.vejobroliai.lt/3697-thickbox_default/seba-apsaugu-komplektas-pro-pack-3.jpg" } },
                        Price = 60.39,
                        Description = "Kokybiškos ir tvirtos riešų, kelių ir alkūnių apsaugos visiems riedutininkams, lentų sportininkams ir ne tik. Kelių ir alkūnių apsaugos.Plastikinė apsauginė plokštelė.Minkšta CoolMax medžiaga iš vidaus.Tvirtinimas - elastingi Velcro dirželiai, kuriuos galima užfiksuoti ir nenusiimant riedučių dėl easy on / easy off sistemos.Tinklinė medžiaga apsaugo vidinę kelio pusę nuo prakaitavimo. Riešų apsaugos.Plastikinis nuimamas riešo įtvirtinimas.Vidinė medžiaga su CoolMax technologija, dėl ko rankos neprakaituoja.Greita ir patogi tvirtinimo sistema.Pirmo lygio apsauga.",
                        Categories = new[] { await _categoryRepository.FindByName("Apsaugos") },
                        Property = new Properties() { Gamintojas = "SEBA", Dydis = "L" },
                        SkuCode = "SK875623"
                    };
                    await _itemRepository.AddAsync(item13);
                }
                {
                    Item item14 = new Item
                    {
                        Name = "Powerslide standard Man S",
                        Images = new[] { new Image() { ImageUrl = "http://terrasport.lt/10742-thickbox_default/powerslide-standard-man-apsaugu-komplektas.jpg" } },
                        Price = 29,
                        Description = "Powerslide kompanijos trijų dalių apsaugų komplektas riedutininkams. Anatominės formos dvigubo tankio EVA kempinė su plastikinėmis plokštelėmis. Fiksacija - elastingi Velcro dirželiai ir ergonomiška medvilnės \"rankovė\". Saugumo klasė A+++",
                        Categories = new[] { await _categoryRepository.FindByName("Apsaugos") },
                        Property = new Properties() { Gamintojas = "Powerslide", Dydis = "S" },
                        SkuCode = "SK321256"
                    };
                    await _itemRepository.AddAsync(item14);
                }
                {
                    Item item15 = new Item
                    {
                        Name = "Powerslide standard Man M",
                        Images = new[] { new Image() { ImageUrl = "http://terrasport.lt/10742-thickbox_default/powerslide-standard-man-apsaugu-komplektas.jpg" } },
                        Price = 29,
                        Description = "Powerslide kompanijos trijų dalių apsaugų komplektas riedutininkams. Anatominės formos dvigubo tankio EVA kempinė su plastikinėmis plokštelėmis. Fiksacija - elastingi Velcro dirželiai ir ergonomiška medvilnės \"rankovė\". Saugumo klasė A+++",
                        Categories = new[] { await _categoryRepository.FindByName("Apsaugos") },
                        Property = new Properties() { Gamintojas = "Powerslide", Dydis = "M" },
                        SkuCode = "SK321257"
                    };
                    await _itemRepository.AddAsync(item15);
                }
                {
                    Item item16 = new Item
                    {
                        Name = "Ennui City Brace",
                        Images = new[] { new Image() { ImageUrl = "http://terrasport.lt/10858-thickbox_default/riesu-apsaugos-ennui-city-brace.jpg " }, new Image() { ImageUrl = "http://terrasport.lt/10859-thickbox_default/riesu-apsaugos-ennui-city-brace.jpg " } },
                        Price = 39,
                        Description = "Riešų apsaugos Ennui Allround Wrist Brace. Riešas įtvirtinamas dviem anatomiškai išformuotais aliumininiais įtvarais apsisaugojimui nuo traumos krintant. Neopreninė įmautė leidžia rankai maksimaliai kvėpuoti ir maloniai priglunda prie plaštakos. Tvirtinama dviem Velcro dirželiais su papildoma fiksacijos apsauga.",
                        Categories = new[] { await _categoryRepository.FindByName("Apsaugos") },
                        Property = new Properties() { Gamintojas = "Enmui", Dydis = "M" },
                        SkuCode = "SK321369"
                    };
                    await _itemRepository.AddAsync(item16);
                }
                {
                    Item item16 = new Item
                    {
                        Name = "Autobahn Nexus",
                        Images = new[] { new Image() { ImageUrl = "http://terrasport.lt/9355-thickbox_default/ratukai-riedlentei-autobahn-nexus-52x30-100a.jpg" } },
                        Price = 29,
                        Discount = 0.1,
                        Description = "Komplekte 4 vienetai.",
                        Categories = new[] { new Category() { Name = "Ratai" } },
                        Property = new Properties() { Dydis = "52mm", Storis = "30mm", Kietumas = "100A", Skirta = "Riedlentėms" },
                        SkuCode = "SK126756"
                    };
                    await _itemRepository.AddAsync(item16);
                }
                {
                    Item item17 = new Item
                    {
                        Name = "Powerslide DEFCON RTS",
                        Images = new[] { new Image() { ImageUrl = "http://terrasport.lt/10877-thickbox_default/rieduciu-ratukai-powerslide-defcon-rts-80mm.jpg" } },
                        Price = 32,
                        Discount = 0.1,
                        Description = "Powerslide kompanijos riedučių ratukai Defcon RTS, pagaminti iš dvigubo kietumo medžiagos. Vidinis minkštas sluoksnis lemia puikų vibracijos sugėrimą, išorinis kietesnis - tinkamą sukibimą su važiuojamąją danga ir didesnį greitį. Grubus ratuko apdirbimas leidžia lengviau atlikti slydimus - \"powerslide'us\". RTS - Ready to Slide! Komplekte 4 vienetai.",
                        Categories = new[] { await _categoryRepository.FindByName("Ratai") },
                        Property = new Properties() { Dydis = "80mm", Kietumas = "85A", Skirta = "Riedučiams" },
                        SkuCode = "SK513548"
                    };
                    await _itemRepository.AddAsync(item17);
                }
                {
                    Item item18 = new Item
                    {
                        Name = "SEBA Luminous",
                        Images = new[] { new Image() { ImageUrl = "http://terrasport.lt/10768-thickbox_default/rieduciu-ratukai-seba-luminous-violetiniai.jpg" } },
                        Price = 30,
                        Discount = 0.1,
                        Description = "Šviečiantys SEBA kompanijos ratukai LUMINOUS. Dėl didesnio LED lempučių kiekio ir kokybės šie ratukai yra ypač ryškūs, o aukštos kokybės tarpinės-generatoriaus šie ratukai niekada nenustos šviesti.",
                        Categories = new[] { await _categoryRepository.FindByName("Ratai") },
                        Property = new Properties() { Dydis = "62mm", Kietumas = "85A", Skirta = "Riedučiams" },
                        SkuCode = "SK189456"
                    };
                    await _itemRepository.AddAsync(item18);
                }
                {
                    Item item19 = new Item
                    {
                        Name = "Wicked SUS Rustproof",
                        Images = new[] { new Image() { ImageUrl = "http://terrasport.lt/10535-thickbox_default/guoliukai-wicked-sus-rustproof.jpg " } },
                        Price = 73.90,
                        Description = "Wicked kompanijos SUS Rustproof guoliai pagaminti iš aukščiausios kokybės medžiagų. Freespin technologija mažina trintį guolyje, taip pagerindama riedėjimo kokybę bei guolio tarnavimo laiką. Šie guoliukai yra puikus pasirinkimas tiems kas mėgsta riedėti visus metus, guoliukai pritaikyti visoms oro sąlygoms. Uždengta guolio viena pusė sukurta patogiam išvalymui ir sutepimui. Sukurti riedučiams, tačiau tinka ir riedlentėms, paspirtukams. Komplekte - 16vnt.",
                        Categories = new[] { new Category() { Name = "Guoliai" } },
                        Property = new Properties() { },
                        SkuCode = "SK956231"
                    };
                    await _itemRepository.AddAsync(item19);
                }
                //Uzsakymai
                {
                    List<int> list = new List<int>
                {
                    4
                };
                    var items = await _itemRepository.GetItemsByIds(list);
                    var item = await _itemRepository.GetByIdAsync(4);
                    var user = await _userRepository.GetByIdAsync(1);
                    var order = new Order
                    {
                        DeliveryAddress = user.City + " " + user.Street + " " + user.HouseNumber,
                        Items = items.ToList(),
                        OrderStatus = "Renkamas",
                        ItemsQty = "1,",
                        TotalPrice = item.Price,
                        User = user
                    };
                    var addedOrder = await _orderRepository.AddAsync(order);
                }
                {
                    List<int> list = new List<int>
                {
                    15,
                    19
                };
                    var items = await _itemRepository.GetItemsByIds(list);
                    var item1 = await _itemRepository.GetByIdAsync(15);
                    var item2 = await _itemRepository.GetByIdAsync(19);
                    var user = await _userRepository.GetByIdAsync(1);
                    var order = new Order
                    {
                        DeliveryAddress = user.City + " " + user.Street + " " + user.HouseNumber,
                        Items = items.ToList(),
                        OrderStatus = "Pristatytas",
                        ItemsQty = "1,4,",
                        TotalPrice = item1.Price + item2.Price * 4,
                        User = user
                    };
                    var addedOrder = await _orderRepository.AddAsync(order);
                }
                {
                    List<int> list = new List<int>
                {
                    9,
                    16
                };
                    var items = await _itemRepository.GetItemsByIds(list);
                    var item1 = await _itemRepository.GetByIdAsync(9);
                    var item2 = await _itemRepository.GetByIdAsync(16);
                    var user = await _userRepository.GetByIdAsync(2);
                    var order = new Order
                    {
                        DeliveryAddress = user.City + " " + user.Street + " " + user.HouseNumber,
                        Items = items.ToList(),
                        OrderStatus = "Išsiųstas",
                        ItemsQty = "2,2,",
                        TotalPrice = item1.Price * 2 + item2.Price * 2,
                        User = user
                    };
                    var addedOrder = await _orderRepository.AddAsync(order);
                }
                {
                    List<int> list = new List<int>
                {
                    5
                };
                    var items = await _itemRepository.GetItemsByIds(list);
                    var item1 = await _itemRepository.GetByIdAsync(5);
                    var user = await _userRepository.GetByIdAsync(3);
                    var order = new Order
                    {
                        DeliveryAddress = user.City + " " + user.Street + " " + user.HouseNumber,
                        Items = items.ToList(),
                        OrderStatus = "Priimtas",
                        ItemsQty = "1,",
                        TotalPrice = item1.Price,
                        User = user
                    };
                    var addedOrder = await _orderRepository.AddAsync(order);
                }
            }
            catch (Exception e)
            {
                _logger.Log(e.Message + e.StackTrace);
            }
        }
    }
}