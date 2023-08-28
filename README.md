# StoreApplication

Bu proje, ASP.NET Core tabanlı bir alışveriş sitesi örneğidir.

## Gereksinimler

Projenin düzgün çalışabilmesi için aşağıdaki gereksinimlere ihtiyaç vardır:

- .NET Core SDK (versiyon: 6.0.0)
- Visual Studio veya Visual Studio Code (isteğe bağlı)
- Bir tarayıcı (örneğin, Google Chrome)

## Kullanılan Paketler

Projede kullanılan her bir class library için gerekli paketler aşağıda listelenmiştir:

### StoreApp.Entites

- > Microsoft.AspNetCore.Identity.EntityFrameworkCore 6.0.0


### StoreApp.Repositories

- Microsoft.EntityFrameworkCore  6.0.0
- Microsoft.EntityFrameworkCore.Sqlite  6.0.0 

### StoreApp.Services

- AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.1

### StoreApp.UI

-   Microsoft.EntityFrameworkCore.Design                  6.0.0     6.0.0
-   Microsoft.EntityFrameworkCore.Tools                   6.0.0     6.0.0
-   Microsoft.VisualStudio.Web.CodeGeneration.Design      6.0.16    6.0.16
    
## Kurulum

1. Projeyi kendi bilgisayarınıza kopyalamak için `git clone` komutunu kullanabilirsiniz.
2. Projeyi Visual Studio veya Visual Studio Code gibi bir geliştirme ortamında açın.
3. Veritabanı ayarlarını `appsettings.json` dosyasında yapılandırın.

## Kullanım

1. Projeyi başlattıktan sonra tarayıcınızda `http://localhost:5000` adresine gidin.
2. Ürünleri görüntüleyebilir, istediğiniz ürünü sepete ekleyebilir ve sepeti kontrol edebilirsiniz.
3. Sipariş vermek için "Sipariş Ver" butonuna tıklayarak sipariş işlemini tamamlayabilirsiniz.

## Dışardan Yardım ve Kaynaklar

Bu projeyi geliştirirken aşağıdaki kaynaklardan faydalanılmıştır:

- [ASP.NET Core Resmi Dokümantasyonu](https://docs.microsoft.com/en-us/aspnet/core)
- [Entity Framework Core Dokümantasyonu](https://docs.microsoft.com/en-us/ef/core/)
- [Bootstrap Dökümantasyonu](https://getbootstrap.com/docs/5.0/getting-started/introduction/)
- [Video] https://www.btkakademi.gov.tr/portal/course/asp-net-core-mvc-25318
- 


## Lisans

Bu proje [MIT Lisansı](LICENSE) altında lisanslanmıştır.
