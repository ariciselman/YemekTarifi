USE [YemekTarifi]
GO
/****** Object:  Table [dbo].[GununYemegi]    Script Date: 25.08.2023 00:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GununYemegi](
	[GununYemegiID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nchar](10) NULL,
	[Malzemeler] [nchar](10) NULL,
	[Tarif] [nchar](10) NULL,
	[Tarih] [smalldatetime] NULL,
	[YemekID] [int] NULL,
 CONSTRAINT [PK_GununYemegi] PRIMARY KEY CLUSTERED 
(
	[GununYemegiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kategoriler]    Script Date: 25.08.2023 00:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategoriler](
	[KategoriID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [varchar](50) NULL,
	[Adet] [smallint] NULL,
	[Resim] [varchar](50) NULL,
 CONSTRAINT [PK_Kategoriler] PRIMARY KEY CLUSTERED 
(
	[KategoriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kullanıcıs]    Script Date: 25.08.2023 00:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kullanıcıs](
	[KullanıcıID] [int] IDENTITY(1,1) NOT NULL,
	[KullanıcıAdı] [varchar](30) NULL,
	[Eposta] [varchar](50) NULL,
	[Sifre] [varchar](30) NULL,
	[AdminMi?] [bit] NULL,
 CONSTRAINT [PK_kullanıcıs] PRIMARY KEY CLUSTERED 
(
	[KullanıcıID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yemekler]    Script Date: 25.08.2023 00:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yemekler](
	[YemekID] [int] IDENTITY(1,1) NOT NULL,
	[YemekAd] [varchar](50) NULL,
	[Malzeme] [varchar](500) NULL,
	[Tarif] [varchar](max) NULL,
	[Resim] [varchar](100) NULL,
	[Tarih] [smalldatetime] NULL,
	[Puan] [tinyint] NULL,
	[Yorum] [varchar](500) NULL,
	[KategoriID] [int] NULL,
	[KullanıcıID] [int] NULL,
 CONSTRAINT [PK_Yemekler] PRIMARY KEY CLUSTERED 
(
	[YemekID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yonetici]    Script Date: 25.08.2023 00:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yonetici](
	[YoneticiID] [tinyint] IDENTITY(1,1) NOT NULL,
	[Ad] [varchar](50) NULL,
	[Sıfre] [varchar](50) NULL,
 CONSTRAINT [PK_Yonetici] PRIMARY KEY CLUSTERED 
(
	[YoneticiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yorumlar]    Script Date: 25.08.2023 00:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yorumlar](
	[YorumID] [nchar](10) NOT NULL,
	[Icerik] [varchar](500) NULL,
	[Tarih] [smalldatetime] NULL,
	[Onay] [bit] NULL,
	[YemekID] [int] NULL,
	[KullanıcıID] [int] NULL,
 CONSTRAINT [PK_Yorumlar] PRIMARY KEY CLUSTERED 
(
	[YorumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Kategoriler] ON 

INSERT [dbo].[Kategoriler] ([KategoriID], [Ad], [Adet], [Resim]) VALUES (8, N'Et Yemekleri', 11, NULL)
INSERT [dbo].[Kategoriler] ([KategoriID], [Ad], [Adet], [Resim]) VALUES (1008, N'Tatlılar', 20, NULL)
INSERT [dbo].[Kategoriler] ([KategoriID], [Ad], [Adet], [Resim]) VALUES (1009, N'Çorba Tarifleri', 8, NULL)
INSERT [dbo].[Kategoriler] ([KategoriID], [Ad], [Adet], [Resim]) VALUES (1010, N'Dolma-Sarma Tarifleri', 14, NULL)
INSERT [dbo].[Kategoriler] ([KategoriID], [Ad], [Adet], [Resim]) VALUES (1011, N'Kahvaltılık', 13, NULL)
INSERT [dbo].[Kategoriler] ([KategoriID], [Ad], [Adet], [Resim]) VALUES (1012, N'Sebze Yemekleri', 17, NULL)
INSERT [dbo].[Kategoriler] ([KategoriID], [Ad], [Adet], [Resim]) VALUES (1013, N'Salatalar', 6, NULL)
INSERT [dbo].[Kategoriler] ([KategoriID], [Ad], [Adet], [Resim]) VALUES (1014, N'Makarnalar ', 9, NULL)
INSERT [dbo].[Kategoriler] ([KategoriID], [Ad], [Adet], [Resim]) VALUES (1015, N'Diyet Yemekleri', 8, NULL)
SET IDENTITY_INSERT [dbo].[Kategoriler] OFF
GO
SET IDENTITY_INSERT [dbo].[kullanıcıs] ON 

INSERT [dbo].[kullanıcıs] ([KullanıcıID], [KullanıcıAdı], [Eposta], [Sifre], [AdminMi?]) VALUES (1, N'selman', N'm.selmanarici@gmail.com', N'12345678', 1)
SET IDENTITY_INSERT [dbo].[kullanıcıs] OFF
GO
SET IDENTITY_INSERT [dbo].[Yemekler] ON 

INSERT [dbo].[Yemekler] ([YemekID], [YemekAd], [Malzeme], [Tarif], [Resim], [Tarih], [Puan], [Yorum], [KategoriID], [KullanıcıID]) VALUES (1, N'Köz Biberli Yoğurtlu Patates Salatası', N'3-4 adet patates 4 adet kornişon turşu 3 adet közlenmiş biber 1 adet havuç 3 dal taze soğan 1 tutam taze nane 2 su bardağı yoğurt 5 yemek kaşığı mayonez 2-3 diş ezilmiş sarımsak Tuz 1 çay bardağı haşlanmış mısır', N'1-Öncelikle patatesleri ortadan iki keselim ve bol suda haşlayalım. Ortadan kesildiğinde patatesler daha kolay haşlanacaktır. 2-Çatalla haşlandığını kontrol ettikten sonra ocaktan alalım, suyunu süzdürerek ve soğumaya bırakalım 3-Kornişon turşuları küçük küçük doğrayalım. 4-Közlenmiş kırmızı biberi de küp küp doğrayalım. 5-Havucun kabuklarını soyalım ve rendeleyelim, taze soğan ve naneyi doğrayalım. 6-Soğuyan patateslerin kabuklarını soyalım ve onları da küp küp doğrayalım. 7-Geniş bir kaseye yoğurdu, mayonezi, ezilmiş sarımsakları ve tuzu alarak karıştıralım. 8-Üzerine havucu, kırmızı biberi, kornişon turşuyu, mısırı, doğradığımız yeşillikleri ve patatesleri ekleyerek karıştıralım ve servis edelim. Afiyet olsun!', NULL, CAST(N'2023-08-23T14:12:00' AS SmallDateTime), NULL, NULL, 8, NULL)
INSERT [dbo].[Yemekler] ([YemekID], [YemekAd], [Malzeme], [Tarif], [Resim], [Tarih], [Puan], [Yorum], [KategoriID], [KullanıcıID]) VALUES (2, N'İzmir Köfte', N'Köftesi için:  500 gram az yağlı kıyma 1 adet kuru soğan 1 adet yumurta 1/2 (yarım) demet maydanoz 1,5 su bardağı bayat ekmek içi Karabiber Kırmızı pul biber Kekik Tuz Diğer malzemeler;  4 adet domates (3 adedi sosu için, 1 adedi de üzerine dilimlemek için gerekiyor) 4 adet patates (ufaksa 5 tane de koyabilirsiniz) 3 adet çarliston biber 1 tatlı kaşığı salça (tercihen karışık) 3 yemek kaşığı sıvı yağ (sos için) Kızartmak için:  Sıvı yağ', N'1-Ekmek içini ve arkasından soğanı rondodan geçiriyoruz. (isterseniz rendeleyip, ufalayabilirsiniz) 2-Yumurtayı, ince ince doğranmış maydanozu, baharatları ve kıymayı da ekleyip iyice yoğuruyoruz. 3-Parmak uzunluğunda ince ve uzun bir şekil verip biraz dinlenmesi için tabağa sıralıyoruz. 4-Patatesleri soyup, elma dilimi şeklinde keselim. Patateslerle köfteler aynı boy olursa, daha şık gözükecektir. 5-Sıvı yağı iyice kızdırıp (çok yağ çekmesin diye) önce patatesleri arkasından da köfteleri azıcık kızartıyoruz. (kesinlikle iyice pişirmeyin ağır olur, kızarmadan almamız gerekiyor) 6-Daha sonra tepsiye, yan yana olacak şekilde bir patates bir köfte şeklinde sıralayın. 7-Sonrasında sos tenceremize sıvı yağımızı alıyoruz, salçamızı da ekleyip iyice karıştıralım. 8-Arkasından rendelediğimiz 3 adet domatesi de ekleyip 10 dakika pişmeye bırakalım, isterseniz sarımsak da atabilirsiniz içine. Kekik ve tuzunu da ekledikten bir kaç dakika sonra ocaktan alıyoruz. Bu aşamada sosun içerisine 1,5 su bardağı su ekleyerek de yapabilirsiniz dilerseniz eklemeden yemeği fırına koymadan önce tepsinize 1 su bardağı sıcak su da ekleyebilirsiniz. 9-Hazırlanan sosu patates ve köftelerin üzerine hepsine değecek şekilde döküyoruz ki kurumasın pişerken. 10-Üzerine 1 adet soyulup dilimlenmiş domatesi sıralıyoruz, biberleri de kesip içini temizledikten sonra aralarına yerleştiriyoruz. 11-Fırına atmadan önce tepsinin kenarından 1 çay bardağı sıcak su koyup önceden ısıtılmış 180°C fırında patateslerin üzeri kızarana kadar pişiriyoruz. (Benim yemek tam 1 saatte istediğim kıvamda pişti, fırından fırına değişiklik gösterebileceği için 20-25 dakikada pişmesi de mümkün, kontrollü olmalısınız.) 12-Dilerseniz 30. dakikadan sonra açıp, tepsinin içindeki sostan köftelerin ve patateslerin üzerine biraz gezdirin. (daha lezzetli olacaktır)ekleyerek karıştıralım ve servis edelim. Afiyet olsun!', NULL, CAST(N'2023-08-12T15:33:00' AS SmallDateTime), NULL, NULL, 8, NULL)
INSERT [dbo].[Yemekler] ([YemekID], [YemekAd], [Malzeme], [Tarif], [Resim], [Tarih], [Puan], [Yorum], [KategoriID], [KullanıcıID]) VALUES (3, N'Kıbrıs Tatlısı', N'3 adet yumurta Yarım su bardağı şeker Yarım su bardağı sıvı yağ 1 su bardağı galeta unu 1 su bardağı kırılmış ceviz 1 su bardağı Hindistan cevizi 1 paket kabartma tozu Kreması İçin;  1 litre süt 1 su bardağı nişasta Yarım su bardağı şeker 1 paket vanilya 1 paket krem şanti Şerbeti İçin;  2 su bardağı su 1,5 su bardağı şeker 1 paket vanilya', N'1-Kıbrıs tatlısı yapmak için, öncelikle şerbeti yapın çünkü kekin üzerine şerbet soğuk dökülecek. Bir tencereye suyu ve şekeri dökün. Kaynamaya başladıktan sonra altını kısıp, 15 dakika daha kaynatın. 2-Şerbet hazır olunca altını kapatın ve vanilyayı ekleyip, soğuması için bekletin. 3-Keki için; yumurtaları ve şekeri iyice çırpın. Diğer malzemeleri de ekleyip, karıştırın. 4-Yağlanmış bir tepsiye (ben büyük kare borcam kullandım) dökün. 5-160 derece fırında, 30 dakika pişirin. 6-Fırından çıkar çıkmaz soğuk şerbeti üzerine dökün ve soğuması için bekletin. 7-Kreması için; krem şanti hariç diğer malzemeleri bir tencerede muhallebi kıvamına gelene kadar pişirin. 8-Altını kapatın, toz krem şantiyi ekleyin ve blenderla 5 dakika çırpın. 9-Soğumuş şerbetli kekin üzerine, bu kremsi muhallebiyi dökün. 10-Üzerine bolca Hindistan cevizi (ben ceviz serptim) serpin. 11-Kıbrıs tatlısını, buzdolabında 2-3 saat bekletip servis yapın. 12-Kıbrıs tatlısı tarifi arayanlara, bu tarifi denemelerini tavsiye ederim. Şimdiden afiyet olsun.', NULL, CAST(N'2023-08-12T15:35:00' AS SmallDateTime), NULL, NULL, 1008, NULL)
INSERT [dbo].[Yemekler] ([YemekID], [YemekAd], [Malzeme], [Tarif], [Resim], [Tarih], [Puan], [Yorum], [KategoriID], [KullanıcıID]) VALUES (4, N'Ezogelin Çorbası', N'1 su bardağı kırmızı mercimek 1 tatlı kaşığı pirinç 1 tatlı kaşığı bulgur 2 çay kaşığı pul biber 1 yemek kaşığı nane 2 diş sarımsak 1 orta boy soğan 1 yemek kaşığı biber salçası 1 yemek kaşığı tereyağı 2 litreye yakın sıcak su Tuz', N'1-Ezogelin çorbası yapmak için düdüklü tencerede önce rendelemiş olduğumuz soğanı ve ezmiş olduğumuz sarımsağı tereyağında kavuruyoruz. Soğanlar diriliğini kaybetsin yeterli yakmadan orta ateşte kavuralım. 2-Soğanlar kavrulunca naneyi, kırmızı biberi ve salçayı ilave edip. Kavurmaya devam edelim. 3-Bir iki karıştırdıktan sonra yıkadığımız mercimeği, pirinci, bulguru ve tuzunu da ilave ederek karıştıralım. 4-Başka bir tarafta kaynamakta olan 2 litreye yakın suyu üzerine boşaltalım. 5-Düdüklünün kapağını ve düdüğünü kapattıktan sonra 10 dakika pişiriyoruz. Normal tencerede de yapabilirsiniz ama biraz daha geç pişecektir (yaklaşık 30-40 dakika sürecektir). 6-Ezogelin çorbası tarifimi mutlaka denemenizi öneririm, şimdiden afiyet olsun…', NULL, CAST(N'2023-08-12T15:36:00' AS SmallDateTime), NULL, NULL, 1009, NULL)
INSERT [dbo].[Yemekler] ([YemekID], [YemekAd], [Malzeme], [Tarif], [Resim], [Tarih], [Puan], [Yorum], [KategoriID], [KullanıcıID]) VALUES (5, N'Zeytinyağlı Biber Dolması ', N'2 adet kuru soğan 1 su bardağı pirinç 1 tatlı kaşığı tarçın 1 tatlı kaşığı karabiber Yarım demet maydanoz Birkaç dal taze nane 1 tatlı kaşığı kuru nane 1 tatlı kaşığı şeker Yarım kahve fincanı kuş üzümü Yarım kahve fincanı kadar dolmalık fıstık 1 adet büyük boy domates 1 çay bardağı zeytinyağı Tuz Dolmaların Üzerine Kapak Yapmak İçin;  1 adet küçük boy domates', N'1-Öncelikle iç malzemesi için kuru soğanlar ince yemeklik doğranır ve yarım çay bardağı zeytinyağında kavrulur. 2-Soğanlar kavrulunca rendelenmiş veya robottan geçirilmiş 1 adet domates eklenir ve karıştırılır. 3-Yıkanmış ve suyu süzülmüş pirinçler ilave edilerek hafifçe kavrulur. 4-Dolmalık fıstıklar, kuş üzümü, tarçın, kuru nane, karabiber, toz şeker, tuz ilave edilir. 5-Karıştırılarak ocaktan alınır. Son olarak ince doğranmış maydanoz ve taze naneler eklenir ve güzelce karıştırılır. 6-Diğer taraftan dolmalık biberlerin kapak kısmı açılır ve güzelce yıkanır. 7-Her biberin içine iç harcından doldurularak tencereye yerleştirilir. Burada önemli olan nokta pirinçlerin rahatça şişebilmesi için biberleri çok sıkı bir şekilde ve tepeleme doldurmamak gerekir, yarısını biraz geçecek kadar iç harcı doldurmanız yeterli olacaktır. 8-Dolmaların kapağına kapatmak için bir domates küçük doğranarak her biberin tepesini kapatılır. 9-Daha sonra uygun bir tencereye doldurulur. 10-Son olarak üzerlerine yarım çay bardağı kadar zeytinyağı gezdirilir ve biberlerin yarısına gelecek kadar su ilave edilir. 11-Tencerenin kapağı kapatılarak pişmeye bırakılır. 12-Pirinçler yumuşayıncaya kadar, yaklaşık 20-25 dakika kaynatılır. 13-Soğuduktan sonra servis edilir.', NULL, CAST(N'2023-08-12T15:39:00' AS SmallDateTime), NULL, NULL, 1010, NULL)
INSERT [dbo].[Yemekler] ([YemekID], [YemekAd], [Malzeme], [Tarif], [Resim], [Tarih], [Puan], [Yorum], [KategoriID], [KullanıcıID]) VALUES (6, N'Kahvaltılık Krep Tarifi', N'2 adet yumurta 2 su bardağından biraz az un 2 su bardağı süt (dilerseniz yarı yarıya süt ve su karışık kullanılabilir) 1 çay kaşığı tuz pişirmek için tereyağı veya sıvı yağ', N'1-Krep tarifi hazırlamak için un, süt ve su ile hiç topak kalmayana kadar iyice çırpın. 2-Yumurtaları ekleyin biraz daha çırpın. Kek hamurundan daha akıcı bir kıvamda hamur edin. 3-Teflon tavaya 1 çay kaşığı kadar tereyağı veya sıvı yağ koyup fırça ile yayın. 4-Kızgın tavaya 1 kepçe krep hamuru dökün, sağa sola eğerek yayın. 5-Her iki tarafını çevirerek hafif kızarana kadar orta ateşte pişirin. Tüm harcınız bitene kadar bu işleme devam edin. Krep tarifimiz hazır, afiyet olsun. İyi bir krep yapmak karışımdan çok el becerisi ister. Biraz pratik yapmanız gerekecektir ;) Bu arada hamura tuz koymazsanız reçel veya çikolata sürerek de tüketebilirsiniz. Tuzlu sevenlere ise önerim içine peynir sarılmasıdır. Kahvaltılık krep tarifini deneyecek herkese afiyet olsun :)', NULL, CAST(N'2023-08-12T15:40:00' AS SmallDateTime), NULL, NULL, 1011, NULL)
INSERT [dbo].[Yemekler] ([YemekID], [YemekAd], [Malzeme], [Tarif], [Resim], [Tarih], [Puan], [Yorum], [KategoriID], [KullanıcıID]) VALUES (7, N'Şakşuka', N'4 adet patlıcan 3 adet yeşil biber 1 adet kuru soğan 4 diş sarımsak 4 adet domates 1 tatlı kaşığı domates salçası 1 çay kaşığı şeker Tuz, istenilen baharatlar 1 çay bardağı sıcak su Kızartmak için sıvı yağ', N'1-Patlıcanları küp küp doğrayıp tuzlu suya koyalım, bir müddet bekletelim 2-Daha sonra sıvı yağı uygun bir tavaya alalım, kızdıralım. 3-Tuzlu sudan alıp kuruladığımız patlıcanlarımızı tavaya alalım. 4-Soğan ve sarımsağı da yemeklik doğrayarak az miktarda yağda kavuralım. 5-Yeşil biberleri  doğrayalım ve tavaya alalım. 6-Üzerine rendelediğimiz domatesi ve salçayı da ekleyerek karıştıralım. 7-Bir süre sonra da şeker, tuz, karabiber ve pul biberi ekleyelim ve tekrardan karıştıralım. 8-Sıcak suyu da ilave ederek 4-5 dakika kadar pişirelim. 9-Son olarak kızarttığımız patlıcanları da tavaya alalım ve pişirdiğimiz sos ile harmanlanmasını sağlayalım. Şakşukamız servise hazır, afiyet olsun.', NULL, CAST(N'2023-08-12T15:42:00' AS SmallDateTime), NULL, NULL, 1012, NULL)
INSERT [dbo].[Yemekler] ([YemekID], [YemekAd], [Malzeme], [Tarif], [Resim], [Tarih], [Puan], [Yorum], [KategoriID], [KullanıcıID]) VALUES (8, N'Fırında Makarna Beşamel Soslu', N'1 paket fırın makarna 1 tatlı kaşığı tuz Su Beşamel sos için;  1 çay bardağı sıvı yağ (ya da 2 yemek kaşığı tereyağı) 2 yemek kaşığı un (tepeleme) 4 su bardağı süt (200 ml bardak ile) Yarım silme yemek kaşığı tuz Üzeri için;  Rendelenmiş kaşar peyniri 6-7 parça Tereyağı (yoksa margarin de olabilir)', N'1-Öncelikle makarnamızı tuzlu suda haşlıyoruz. 2-O haşlanırken beşamel sosumuzu hazırlıyoruz. Tüm malzemeleri küçük bir tencerede muhallebi kıvamına gelip fokurdayana kadar karıştırarak pişiriyoruz. 3-Daha sonra makarnamızı süzüp borcama yerleştiriyoruz. (Ben oval borcam kullanıyorum tam geliyor) 4-Daha sonra beşamel sosumuzu üzerine gezdiriyoruz. 5-Kuru bir yer kalmamalı. Sonra üzerine rendelenmiş kaşar peynirimizi serpiyoruz. 6-En son tereyağından bıçak ucuyla kesip küçük parçalar halinde aralıklarla kenarlarına koyuyoruz. 7-Sonunda ortalarına da bir kaç parça koyuyoruz ve 180 derece ısıtılmış fırına sürüyoruz. 8-Yarım saat kadar pişiriyoruz. Size tavsiyem fırında piştikten sonra 15 dakika kadar içini çekmesi için bekletmeniz. Afiyet olsun.', NULL, CAST(N'2023-08-12T15:44:00' AS SmallDateTime), NULL, NULL, 1014, NULL)
INSERT [dbo].[Yemekler] ([YemekID], [YemekAd], [Malzeme], [Tarif], [Resim], [Tarih], [Puan], [Yorum], [KategoriID], [KullanıcıID]) VALUES (9, N'Fırında Kabak Mücver Yapımı', N'4 adet orta boy kabak 2 adet yumurta Yarım demet dereotu 20-25 adet maydanoz 8-10 adet yeşil soğan 200 gram beyaz peynir (diyet yapanlar için light olabilir, miktarı da azaltılabilir) 1 çay bardağı un (kıvama göre azalıp eksilebilir, ben tam buğday unu kullandım) 1 adet kabartma tozu Yarım kahve fincanı sıvı yağ (diyette olmayanlar, isteyenler tam doldurabilir) Tuz, karabiber, pul biber Diyette olmayanlar için üzerine serpmek için 250 gr kaşar peyniri', N'1-Kabakları soyun, rendeleyin ve suyunu sıkarak çıkarın. 2-Diğer yeşillikleri ince ince doğrayın. 3-Beyaz peyniri bir çatal yardımıyla ezin. 4-Yumurtaları ayrı bir kapta iyice çırpın, köpük köpük olsun. 5-Bütün malzemeleri krep yapıyormuş gibi birleştirin. 6-Burada önemli olan unun miktarını ayarlamanız. Çok cıvık olmasın ki içini çekerek pişsin. 7-Fırın kabınızı çok az yağla yağlayın yada pişirme kağıdı kullanabilirsiniz. 8-Tüm malzemeyi kabınıza boşaltın ve önceden 200 derecede ısıtılmış fırınınıza sürün. Süre ve ısı veremeyeceğim, ben turbo fırınımda pişirdim biraz çabuk pişiriyor. Sonra ısıyı düşürüp içini çekmesini sağlıyorum mesela. 9-Kızarmaya başlayınca çıkarıp kaşar peyniri serpin ve kaşarlar eriyip kızarıncaya kadar pişirin. 10-Dileyen sarımsaklı yoğurtla servis edebilir ve dereotu ile süsleyebilir. Afiyet olsun', NULL, CAST(N'2023-08-12T15:45:00' AS SmallDateTime), NULL, NULL, 1015, NULL)
SET IDENTITY_INSERT [dbo].[Yemekler] OFF
GO
SET IDENTITY_INSERT [dbo].[Yonetici] ON 

INSERT [dbo].[Yonetici] ([YoneticiID], [Ad], [Sıfre]) VALUES (1, N'selman', N'12345678')
SET IDENTITY_INSERT [dbo].[Yonetici] OFF
GO
ALTER TABLE [dbo].[GununYemegi] ADD  CONSTRAINT [DF_GununYemegi_GununYemegiTarih]  DEFAULT (getdate()) FOR [Tarih]
GO
ALTER TABLE [dbo].[kullanıcıs] ADD  CONSTRAINT [DF_kullanıcıs_AdminMi?]  DEFAULT ((0)) FOR [AdminMi?]
GO
ALTER TABLE [dbo].[Yemekler] ADD  CONSTRAINT [DF_Yemekler_YemekTarih]  DEFAULT (getdate()) FOR [Tarih]
GO
ALTER TABLE [dbo].[Yorumlar] ADD  CONSTRAINT [DF_Yorumlar_YorumTarih]  DEFAULT (getdate()) FOR [Tarih]
GO
ALTER TABLE [dbo].[Yorumlar] ADD  CONSTRAINT [DF_Yorumlar_YorumOnay]  DEFAULT ((0)) FOR [Onay]
GO
ALTER TABLE [dbo].[GununYemegi]  WITH CHECK ADD  CONSTRAINT [FK_GununYemegi_Yemekler] FOREIGN KEY([YemekID])
REFERENCES [dbo].[Yemekler] ([YemekID])
GO
ALTER TABLE [dbo].[GununYemegi] CHECK CONSTRAINT [FK_GununYemegi_Yemekler]
GO
ALTER TABLE [dbo].[Yemekler]  WITH CHECK ADD  CONSTRAINT [FK_Yemekler_Kategoriler] FOREIGN KEY([KategoriID])
REFERENCES [dbo].[Kategoriler] ([KategoriID])
GO
ALTER TABLE [dbo].[Yemekler] CHECK CONSTRAINT [FK_Yemekler_Kategoriler]
GO
ALTER TABLE [dbo].[Yemekler]  WITH CHECK ADD  CONSTRAINT [FK_Yemekler_kullanıcıs] FOREIGN KEY([KullanıcıID])
REFERENCES [dbo].[kullanıcıs] ([KullanıcıID])
GO
ALTER TABLE [dbo].[Yemekler] CHECK CONSTRAINT [FK_Yemekler_kullanıcıs]
GO
ALTER TABLE [dbo].[Yorumlar]  WITH CHECK ADD  CONSTRAINT [FK_Yorumlar_kullanıcıs] FOREIGN KEY([KullanıcıID])
REFERENCES [dbo].[kullanıcıs] ([KullanıcıID])
GO
ALTER TABLE [dbo].[Yorumlar] CHECK CONSTRAINT [FK_Yorumlar_kullanıcıs]
GO
ALTER TABLE [dbo].[Yorumlar]  WITH CHECK ADD  CONSTRAINT [FK_Yorumlar_Yemekler] FOREIGN KEY([YemekID])
REFERENCES [dbo].[Yemekler] ([YemekID])
GO
ALTER TABLE [dbo].[Yorumlar] CHECK CONSTRAINT [FK_Yorumlar_Yemekler]
GO
