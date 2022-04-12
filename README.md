# Assement
Assement

*PersonContactApi : https://localhost:44349/
Personcontact' .Net Core 5 ile yazılmıştır. PersonContact servisin görevi Database'e kişi ekleme,silme,göstreme ve kişiye ait iletişim bilgilerinin eklenmesi silinmesi işlemlerinin gerçekleştirilmesi için yazılmıştır.Database olarak SQL kullanılmıştır.Kişi ve Contact arasında 1'e çok bir ilişki kurulmuştur.ORM olarak Entity Framework kullanulmıştır.

*ReportRequestApi: https://localhost:44337/
ReportRequest kullanıcının sistemden rapor talep etmesi için yazılmıştır.PersonContact gibi .Net Core 5 ile yazılmıştır. Sistem PersonContact'a request atıp oradan bir rapor talep eder ve personcontact api'de raporunu rabbitMQ ' da kuyruğa yollar. ReportRequest'de kuyruğa giden bilgiyi alır ve rapor detayı olarak kendi database'ine rapor saati,uuıd , rapor durumu ve rapor detayları ile beraber SQL server'a kayıt işlemi gerçekleştirir. ORM olarak Entity Framework kullanılmıştır.
