# Assement
Assement

*PersonContactApi : https://localhost:44349/
Personcontact' .Net Core 5 ile yazılmıştır. PersonContact servisin görevi Database'e kişi ekleme,silme,göstreme ve kişiye ait iletişim bilgilerinin eklenmesi silinmesi işlemlerinin gerçekleştirilmesi için yazılmıştır.Database olarak SQL kullanılmıştır.Kişi ve Contact arasında 1'e çok bir ilişki kurulmuştur.ORM olarak Entity Framework kullanulmıştır.

*ReportRequestApi: https://localhost:44337/
ReportRequest kullanıcının sistemden rapor talep etmesi için yazılmıştır.PersonContact gibi .Net Core 5 ile yazılmıştır. Sistem PersonContact'a request atıp oradan bir rapor talep eder ve personcontact api'de raporunu rabbitMQ ' da kuyruğa yollar. ReportRequest'de kuyruğa giden bilgiyi alır ve rapor detayı olarak kendi database'ine rapor saati,uuıd , rapor durumu ve rapor detayları ile beraber SQL server'a kayıt işlemi gerçekleştirir. ORM olarak Entity Framework kullanılmıştır.

Veri Tabanına Ait Görseller :

Projeye ait fotoğrafları sizinle paylaşacağım.

//Burada Eklenen Kullanıcıların Bilgileri Gözükmektedir.

![Kullanıcı Eklenmesi](https://user-images.githubusercontent.com/83523992/156642001-94e8e327-4214-4d44-aac4-dd4ab09adbd9.jpg)

//Kullanıcılar ve kullanıcıların iletişimleri arasında 1'e çok ilişki vardır.(Çoka çok ilişkide yapabilirdim) Burada iletişim bilgisi eklerden postmande tetiklediğimin için 1 tane personId üzerinden devam ettim kodun doğru çalışıp çalışmadığının görebilmek için.
![Kullanıcıya Ait İletişim](https://user-images.githubusercontent.com/83523992/156642039-0ed481a7-416c-4aef-8031-a487d09cca6e.jpg)

//Rapor talep edildiği zaman Person api'den istek gidip istek sonucunda raorun getirilmesi ve database'e kaydedilmesi
![Rapor Talep ](https://user-images.githubusercontent.com/83523992/156642060-c58ad7f8-619a-4e82-96d2-3cd943194a95.jpg)

//Database görünümleri
![Database ](https://user-images.githubusercontent.com/83523992/156642081-95b8b229-9cc8-46c5-b679-0df2d991e6a5.jpg)

//Tablolarda şu bilgiler vs boş geçilebilir denmediği için hepsini required olarak girdim sayılırı.Bu yüzden telefon sorgusunda ve toplam kişi sorgusunun tek seferde
aradan çıkartmış oldum.Eğer telefon sorgusu yapılacak ise groupby yapmadan önce telNum != null yaparak o konumda olanların telefon sayılarını sayabilirim.

Projede swagger yüklü oradan tablo işlemlerini vs gerçekleştirebilirsiniz.Ben isteklerimi POSTMAN üzerinden yaptım.

Projede FORKLAMA ve PULL REQUEST yoktur. Bütün kodlar ŞAHSIM tarafından yazılmıştır.

YARARLANILAN KAYNAKLAR: (Yazmayı unuttuğum kaynaklar olabilir.)

1- https://www.gencayyildiz.com/blog/
2- Youtube : TechBuddy kanalı
3- https://www.pluralsight.com/
4- https://docs.microsoft.com/
5- https://www.c-sharpcorner.com/
6- https://github.com/dotnet-architecture/eShopOnContainers
7- https://www.rabbitmq.com/
8- https://medium.com/@emrebalcii (Docker üzerinden çalıştırmak için) (Normal rabbitmq ve erlang'dillerini kurduğum zaman rabbitMQ ' yü çalıştıramadım bu yüzden şuan Docker üzerinden çalıştırmaktayım. )


