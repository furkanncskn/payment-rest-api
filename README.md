# Kurulum ve Çalıştırma

1. **`Yöntem`**

---

→ İlgili link adresi üzerinde ki projeyi bir dizin içerisine klonlayınız.

```powershell
git clone https://github.com/furkanncskn/payment-rest-api.git
```

→ **Dockerfile** dosyasının bulunduğu dizine gelerek CLI (Command Line Interface) ile beraber Dockerfile dosyası içerisinde yazan kodları çalıştırıp **image**'i oluşturun.

```powershell
docker build -t furkanncskn/tringleapi:v2.0.0 .
```

→ Projeyi çalıştırabilmek için image dosyasını kullanarak bir **container** oluşturun.  Bu kod satırı ile beraber container’ın 80 numaralı portu ile yerel bilgisayarınız da ki 5050 numaralı port üzerinden haberleşme sağlanacaktır. 

```powershell
docker run -p 5050:80 furkanncskn/tringleapi:v2.0.0
```

→ API ye ait dokümantasyonu oluşturmak ve bazı test işlemlerini gerçekleştirebilmek için **postman** aracı kullanılmıştır. Aşağıda ki link üzerinden bu dosyaya erişip gerekli test işlemlerini gerçekleştirebilirsiniz.

```powershell
https://documenter.getpostman.com/view/20566920/UyxoijPm
```

2. **`Yöntem`**

---

 → Projeye ait **Docker Hub** üzerinde ki repository de yer alan image dosyasını indirin.

```powershell
docker pull furkanncskn/tringleapi:v2.0.0
```

→ Projeyi çalıştırabilmek için image dosyasını kullanarak bir container oluşturun.

```powershell
docker run -p 5050:80 furkanncskn/tringleapi:v2.0.0
```

→ Aşağıda ki link üzerinden gerekli test işlemlerini gerçekleştirebilirsiniz.

```powershell
https://documenter.getpostman.com/view/20566920/UyxoijPm
```
