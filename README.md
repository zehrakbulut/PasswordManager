# PASSWORD MANAGER API (ŞİFRE YÖNETİCİSİ)

ASP.NET Core 8.0 ile geliştirilmiş güvenli ve sağlam bir şifre yönetim sistemi. Clean Architecture prensipleri ve CQRS pattern uygulanarak tasarlanmıştır. Bu API, kurumsal seviyede güvenlik özellikleri ile kapsamlı kullanıcı kimlik doğrulama ve şifre saklama yetenekleri sunar.

## 🚀 Özellikler

### Temel Özellikler
- **Kullanıcı Yönetimi**: Eksiksiz kullanıcı kaydı, kimlik doğrulama ve profil yönetimi
- **Şifre Saklama**: Farklı servisler için güvenli şifre depolama ve yönetimi
- **JWT Kimlik Doğrulama**: Yapılandırılabilir süre ile token tabanlı kimlik doğrulama sistemi
- **Şifre Şifreleme**: Ana şifreler için BCrypt ve saklanan şifreler için AES ile çift katmanlı güvenlik
- **RESTful API**: Endüstri standartlarına uygun tasarlanmış REST uç noktaları

### Teknik Özellikler
- **Clean Architecture**: Domain, Application, Infrastructure ve API katmanları ile endişelerin ayrılması
- **CQRS Pattern**: MediatR kullanılarak Command Query Responsibility Segregation
- **FluentValidation**: Özel hata mesajları ile kapsamlı girdi doğrulama
- **AutoMapper**: DTO'lar ve domain modelleri için nesne-nesne eşleştirme
- **Entity Framework Core**: PostgreSQL ile code-first veritabanı yaklaşımı
- **Swagger Dokümantasyonu**: Etkileşimli API dokümantasyonu ve test arayüzü

## 🏗️ Mimari

Proje, Clean Architecture prensiplerini takip ederek aşağıdaki yapıya sahiptir:

```
PasswordManager/
├── PasswordManager.Api/              # API Katmanı (Controllers, Middleware)
├── PasswordManager.Application/      # Uygulama Katmanı (İş Mantığı, DTOs, Features)
├── PasswordManager.Domain/          # Domain Katmanı (Entities, Interfaces)
├── PasswordManager.Infrastructure/  # Altyapı Katmanı (Veri Erişimi, Dış Servisler)
└── README.md
```

### Katman Sorumlulukları

- **Domain**: Temel iş varlıkları ve arayüzler
- **Application**: İş mantığı, CQRS işleyicileri, DTO'lar, doğrulama ve eşleme
- **Infrastructure**: Veri erişimi, dış servisler ve cross-cutting concerns
- **API**: Controller'lar, middleware ve yapılandırma

## 🛠️ Teknoloji Yığını

- **Framework**: .NET 8.0
- **Veritabanı**: PostgreSQL
- **ORM**: Entity Framework Core 8.0
- **Kimlik Doğrulama**: JWT Bearer Token
- **Şifre Hash'leme**: BCrypt.Net
- **Şifreleme**: AES (Advanced Encryption Standard)
- **Doğrulama**: FluentValidation
- **Dokümantasyon**: Swagger/OpenAPI
- **Mimari Desenler**: Clean Architecture, CQRS, Repository Pattern

## 📋 Ön Gereksinimler

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL 12+](https://www.postgresql.org/download/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) veya [Visual Studio Code](https://code.visualstudio.com/)

## ⚙️ Kurulum

### 1. Repository'yi Klonlayın
```bash
git clone https://github.com/zehrakbulut/PasswordManager.git
cd PasswordManager
```

### 2. Veritabanı Kurulumu
1. PostgreSQL'i kurun ve yeni bir veritabanı oluşturun:
```sql
CREATE DATABASE AppDb;
```

2. `PasswordManager.Api/appsettings.json` dosyasındaki bağlantı dizesini güncelleyin:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=AppDb;Username=postgres;Password=123456aA*"
  }
}
```

### 3. JWT Ayarlarını Yapılandırın
`appsettings.json` dosyasındaki JWT yapılandırmasını güncelleyin:
```json
{
 "JwtSettings": {
    "Secret": "GizliBirAnahtarBurayaGelmeli123!",
    "Issuer": "PasswordManagerAPI",
    "Audience": "PasswordManagerClient",
    "ExpiryMinutes": 60
  }
}
```

### 4. Bağımlılıkları Yükleyin
```bash
dotnet restore
```

### 5. Veritabanı Migration'larını Çalıştırın
```bash
dotnet ef database update --project PasswordManager.Infrastructure --startup-project PasswordManager.Api
```

### 6. Uygulamayı Çalıştırın
```bash
dotnet run --project PasswordManager.Api
```

API şu adreslerde kullanılabilir olacak:
- HTTP: `http://localhost:5187`
- HTTPS: `https://localhost:7237`
- Swagger UI: `https://localhost:7237/swagger`

## 📚 API Dokümantasyonu

### Kimlik Doğrulama Uç Noktaları

#### Kullanıcı Kaydı
```http
POST /api/auth/register
Content-Type: application/json

{
  "userName": "john_doe",
  "email": "john@example.com",
  "password": "GuvenliBirSifre123!"
}
```

#### Kullanıcı Girişi
```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "john@example.com",
  "password": "GuvenliBirSifre123!"
}
```

### Kullanıcı Yönetimi Uç Noktaları

#### ID'ye Göre Kullanıcı Getir
```http
GET /api/users/{id}
Authorization: Bearer {jwt_token}
```

#### Kullanıcı Güncelle
```http
PUT /api/users/{id}
Authorization: Bearer {jwt_token}
Content-Type: application/json

{
  "id": 1,
  "userName": "guncellenen_kullanici",
  "email": "guncellenen@example.com",
  "password": "YeniSifre123!"
}
```

#### Tüm Kullanıcıları Listele
```http
GET /api/users/UserList
Authorization: Bearer {jwt_token}
```

### Şifre Yönetimi Uç Noktaları

#### Şifre Kaydı Oluştur
```http
POST /api/passwords
Authorization: Bearer {jwt_token}
Content-Type: application/json

{
  "userId": 1,
  "name": "GitHub",
  "username": "kullanici_adim",
  "password": "BenimGuvenliBirSifrem123!"
}
```

#### ID'ye Göre Şifre Getir
```http
GET /api/passwords/{id}
Authorization: Bearer {jwt_token}
```

#### Şifre Kaydını Güncelle
```http
PUT /api/passwords/{id}
Authorization: Bearer {jwt_token}
Content-Type: application/json

{
  "id": 1,
  "userId": 1,
  "name": "GitHub",
  "username": "kullanici_adim",
  "password": "GuncellenmisSifre123!"
}
```

#### Tüm Şifreleri Listele
```http
GET /api/passwords/PasswordList
Authorization: Bearer {jwt_token}
```

## 🔒 Güvenlik Özellikleri

### Şifre Güvenliği
- **Ana Şifreler**: Salt ile BCrypt kullanılarak hash'lenir
- **Saklanan Şifreler**: AES-256 şifreleme kullanılarak şifrelenir
- **Güvenli Anahtar Yönetimi**: Yapılandırılabilir şifreleme anahtarları

### Kimlik Doğrulama ve Yetkilendirme
- **JWT Token'ları**: Yapılandırılabilir süre ile durumsuz kimlik doğrulama
- **Bearer Token Kimlik Doğrulama**: Standart HTTP yetkilendirme başlıkları
- **Rol Tabanlı Erişim**: Kaynaklara güvenli erişim kontrolü

### Girdi Doğrulama
- **Kapsamlı Doğrulama**: Tüm girdiler FluentValidation kullanılarak doğrulanır
- **Şifre Gereksinimleri**: Güçlü şifre politikaları zorunlu tutulur
- **Veri Temizleme**: Injection saldırılarına karşı koruma

## 🧪 Test

### Unit Testleri Çalıştır
```bash
dotnet test
```

### API Testi
Etkileşimli API testi için entegre Swagger UI kullanın:
1. `https://localhost:7237/swagger` adresine gidin
2. JWT token'ınızı ayarlamak için "Authorize" butonunu kullanın
3. Uç noktaları doğrudan tarayıcıdan test edin

## 🔧 Yapılandırma

### Ortam Değişkenleri
`appsettings.json` dosyasındaki temel yapılandırma seçenekleri:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "PostgreSQL bağlantı dizesi"
  },
  "JwtSettings": {
    "Secret": "JWT gizli anahtarınız (32+ karakter)",
    "Issuer": "Uygulama adınız",
    "Audience": "İstemci adınız",
    "ExpiryMinutes": 60
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

## 🚀 Dağıtım

### Üretim Dağıtımı
1. **Ortam Yapılandırması**: Bağlantı dizelerini ve JWT ayarlarını güncelleyin
2. **Veritabanı Migration**: Üretim ortamında migration'ları çalıştırın
3. **Güvenlik**: Hassas yapılandırma için ortam değişkenlerini kullanın
4. **HTTPS**: SSL/TLS sertifikalarının düzgün yapılandırıldığından emin olun

### Docker Desteği (Opsiyonel)
Konteynerleştirme için bir `Dockerfile` oluşturun:
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PasswordManager.Api.dll"]
```

## 🤝 Katkıda Bulunma

1. Repository'yi fork edin
2. Özellik dalı oluşturun (`git checkout -b feature/harika-ozellik`)
3. Değişikliklerinizi commit edin (`git commit -m 'Harika bir özellik ekle'`)
4. Dalı push edin (`git push origin feature/harika-ozellik`)
5. Pull Request açın

### Geliştirme Kılavuzu
- Clean Architecture prensiplerini takip edin
- Kapsamlı unit testler uygulayın
- Girdi doğrulama için FluentValidation kullanın
- RESTful API konvansiyonlarını takip edin
- Yeni özellikler için dokümantasyonu güncelleyin



## 🔄 Sürüm Geçmişi

- **v1.0.0** - Temel işlevsellik ile ilk sürüm
  - Kullanıcı kimlik doğrulama ve yönetimi
  - Şifre saklama ve şifreleme
  - JWT tabanlı güvenlik
  - RESTful API uç noktaları

---
ZEHRA AKBULUT ♡♡♡
