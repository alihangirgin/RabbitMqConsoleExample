**Temel Fonksiyonlar**

<br>

**QueueDeclare**, RabbitMQ'da bir kuyruk oluşturmak veya var olan bir kuyruğun özelliklerini almak için kullanılan bir yöntemdir. Bu yöntem, bir kuyruk oluşturulurken gerekli olan çeşitli seçenekleri ayarlamanıza olanak tanır. Kuyruklar, mesajların gönderilip alındığı yerlerdir ve RabbitMQ sistemindeki temel veri yapılarından biridir.

**QueueDeclare Parametreleri**

**queue**: Kuyruğun adını belirtir. Boş bir string ("") verilirse, RabbitMQ rastgele bir kuyruk adı oluşturur ve bu adı geri döndürür.

**durable**: Kuyruğun kalıcı olup olmadığını belirtir. true ayarlandığında, kuyruk sunucu yeniden başlatıldığında da var olmaya devam eder. Ancak, bu yalnızca kuyruğun kalıcı hale getirilmesini sağlar; mesajlar kalıcı hale getirilmez.

**exclusive**: Kuyruğun yalnızca bağlantı kurulduğunda ve bağlantı kesildiğinde silinecek şekilde yalnızca bu bağlantıya özel olup olmadığını belirtir. true ayarlandığında, kuyruk yalnızca o bağlantıya özel olur ve bağlantı kapatıldığında silinir.

**autoDelete**: Kuyruğun, tüketici kalmadığında otomatik olarak silinip silinmeyeceğini belirtir. true ayarlandığında, kuyruğun son tüketicisi bağlantısını kestiğinde kuyruk silinir.

**arguments**: Kuyruğun özelliklerini daha ayrıntılı ayarlamak için bir sözlük nesnesi kullanılır. Örneğin, TTL (time-to-live), mesaj sınırları gibi özel ayarlar yapılabilir.

<br>

**BasicPublish**, RabbitMQ'da bir üreticinin (producer) mesajları bir değişime (exchange) göndermesini sağlayan bir yöntemdir. Bu yöntem, mesajın hangi değişime gönderileceğini ve değişimin mesajı hangi kuyruğa yönlendireceğini belirler. BasicPublish, RabbitMQ'daki mesajlaşma sürecinin temel bir parçasıdır ve mesajların doğru bir şekilde iletilmesini sağlar.

**BasicPublish Parametreleri**

**exchange**: Mesajın gönderileceği değişimin adını belirtir. Boş bir string ("") verilirse, RabbitMQ varsayılan değişim (default exchange) kullanılır. Varsayılan değişim, mesajları doğrudan routingKey ile belirtilen kuyruk adına yönlendirir.

**routingKey**: Mesajın hedef kuyruğunu belirlemek için kullanılan anahtardır. Fanout değişim türü dışında, diğer değişim türlerinde (Direct, Topic, Headers) yönlendirme anahtarı kullanılır.

**basicProperties**: Mesajın özelliklerini (örneğin, mesaj kalıcılığı, başlıklar, vb.) belirlemek için kullanılan bir nesnedir. Bu, IBasicProperties arayüzü ile sağlanır.

**body**: Gönderilecek mesajın içeriğidir. Bu, genellikle bir byte dizisi (byte[]) olarak gönderilir.

<br>

**BasicConsum**e, RabbitMQ'da bir tüketicinin belirli bir kuyruğa abone olmasını sağlayan bir yöntemdir. Bu yöntem, kuyruktaki mesajları asenkron olarak alarak işlemeye başlar. Tüketici, kuyruğa gelen mesajları bir olay veya bir geri çağırma fonksiyonu aracılığıyla alır ve işler.

**BasicConsume Parametreleri**

**queue**: Tüketicinin abone olacağı kuyruğun adını belirtir.

**autoAck**: Otomatik onaylama olup olmadığını belirtir. true olarak ayarlandığında, RabbitMQ mesajın teslim edildiğini kabul eder ve mesajı kuyruktan siler. false olarak ayarlandığında, mesajın işlenmesi tamamlandığında manuel olarak onaylanması gerekir.

**consumer**: Mesajları almak için kullanılacak tüketici nesnesini belirtir. Genellikle EventingBasicConsumer sınıfı kullanılır.

<br>

**BasicQos** yöntemi, RabbitMQ'daki tüketicilerin mesajları nasıl aldığını kontrol etmenizi sağlayan bir yöntemdir. Bu yöntem, mesajların adil bir şekilde dağıtılmasını ve tüketicilerin aşırı yüklenmesini önlemeye yardımcı olur. Özellikle mesajların çok hızlı bir şekilde kuyruktan tüketiciye aktarılması durumunda faydalıdır.

**BasicQos Parametreleri**

**prefetchSize**: Mesajların önceden alınacak toplam boyutunu belirtir. Genellikle 0 olarak ayarlanır, bu da mesaj boyutunun sınırsız olduğunu gösterir.

**prefetchCount**: Tüketiciye önceden gönderilecek maksimum mesaj sayısını belirtir. Bu değer genellikle 1 olarak ayarlanır, bu da her bir tüketicinin aynı anda yalnızca bir mesaj almasını ve işlediği sürece başka mesaj almamasını sağlar.

**global**: Bu parametre, prefetchSize ve prefetchCount ayarlarının kanal düzeyinde mi yoksa tüketici düzeyinde mi uygulanacağını belirtir. true olarak ayarlanırsa kanal düzeyinde, false olarak ayarlanırsa tüketici düzeyinde uygulanır.

<br><br>

**Exchange Türleri**

<br>

**Default Exchange**, RabbitMQ'da varsayılan olarak sağlanan bir değişim (exchange) türüdür. Bu değişim, mesajların yönlendirilmesinde basit ve doğrudan bir yol sağlar ve genellikle doğrudan (direct) exchange türünde çalışır.

**Default Exchange Özellikleri**
- **Varsayılan Yönlendirme**: Default exchange, adı boş olan ("") bir direct exchange'dir. Bu nedenle, mesajları belirli bir kuyruk adı ile doğrudan yönlendirmek için kullanılır.

- **Direct Yönlendirme**: Mesajlar, routing key olarak belirtilen kuyruk adlarına doğrudan yönlendirilir. Bu, mesajların belirli bir kuyruk adıyla eşleşmesi ve yönlendirilmesi anlamına gelir.

- **Kullanım Kolaylığı**: Default exchange, üreticiler tarafından yönlendirme anahtarı olarak kuyruk adını doğrudan kullanarak mesajların gönderilmesini sağlar. Bu, basit senaryolar için kullanışlıdır.

**Örnek Açıklamaları**
- **Default Exchange Kullanımı**: exchange: "" olarak ayarlandığında, mesajlar varsayılan exchange'e gönderilir. Bu, routing key olarak belirtilen kuyruk adını doğrudan kullanır.

- **Yönlendirme Anahtarı**: routingKey: "my_queue" ayarı, mesajın doğrudan "my_queue" kuyruk adına yönlendirilmesini sağlar.

- **Kuyruk Tanımlama**: Tüketici, mesajların alınabilmesi için "my_queue" adında bir kuyruk tanımlar ve bu kuyruğa abone olur.

 Default Exchange, RabbitMQ'daki en basit değişim türlerinden biridir ve mesajların hızlı bir şekilde doğrudan kuyruklara yönlendirilmesini sağlar. Bu, özellikle basit yönlendirme senaryoları için kullanışlıdır. 

<br><br>

**Fanout Exchange**, RabbitMQ'da bir tür değişim (exchange) modelidir ve mesajları doğrudan tüm bağlı kuyruklara yayınlamak için kullanılır. Bu model, bir mesajın aynı anda birden fazla kuyruğa dağıtılması gerektiğinde kullanılır ve genellikle yayınlama (broadcast) senaryoları için uygundur.

**Fanout Exchange Özellikleri**

- **Yayınlama**: Fanout exchange, bir mesaj aldığında, bağlı olduğu tüm kuyruklara mesajı kopyalar ve gönderir. Routing key dikkate alınmaz, bu nedenle mesajlar tüm kuyruklara gönderilir.

- **Yönlendirme Anahtarı (Routing Key)**: Fanout exchange, yönlendirme anahtarını (routing key) dikkate almaz. Yani, üretici mesaj gönderirken herhangi bir yönlendirme anahtarı belirtse bile bu anahtar dikkate alınmaz.

- **Uygulama Senaryoları**: Genellikle, bildirimler, yayınlar veya güncellemelerin geniş bir kitleye dağıtılması gerektiğinde kullanılır. Örneğin, bir chat uygulamasında mesajların tüm kullanıcılar arasında paylaşılması için fanout exchange kullanılabilir.

**Örnek Açıklamaları**
- **Exchange Tanımlama**: Hem üretici hem de tüketici, "fanout-logs" adında bir fanout exchange tanımlar. Tüketiciler, mesajları almak için bu exchange'e bağlanırlar.

- **Geçici Kuyruk**: Tüketici, fanout exchange'den mesajları almak için bir geçici kuyruk oluşturur (channel.QueueDeclare().QueueName). Bu kuyruk, tüketici bağlantısını kapattığında otomatik olarak silinir.

- **Kuyruk Bağlama**: Tüketici, kuyrukları fanout exchange'e bağlamak için QueueBind yöntemini kullanır. Bu işlem, exchange'den kuyruklara mesajların yönlendirilmesini sağlar.

- **Mesaj Yayını**: Üretici, mesajları exchange'e gönderir. Fanout exchange, bu mesajları bağlı tüm kuyruklara dağıtır.

  Fanout exchange, bir mesajın birden fazla hedefe ulaştırılması gerektiği durumlar için ideal bir çözümdür. Bu yapı, mesajların geniş kitlelere hızlı bir şekilde dağıtılmasını sağlar.

<br><br>

**Direct Exchange**, RabbitMQ'da bir tür değişim (exchange) modelidir ve mesajların belirli bir yönlendirme anahtarı (routing key) ile tam eşleşen kuyruğa gönderilmesini sağlar. Bu model, mesajların belirli bir hedefe hassas bir şekilde yönlendirilmesi gerektiğinde kullanılır.

**Direct Exchange Özellikleri**
- **Yönlendirme Anahtarı (Routing Key)**: Mesajın hangi kuyruğa yönlendirileceğini belirlemek için kullanılır. Her kuyruk, belirli bir yönlendirme anahtarı ile değişime bağlanır.

- **Tam Eşleşme**: Direct exchange, mesajın yönlendirme anahtarını ve kuyruğun bağlı olduğu yönlendirme anahtarını karşılaştırır ve yalnızca tam eşleşen kuyruklara mesajları gönderir.

- **Uygulama Senaryoları**: Tipik olarak, hata ayıklama ve loglama gibi belirli mesajların belirli tüketicilere veya hizmetlere yönlendirilmesi gereken senaryolarda kullanılır.

 **Örnek Açıklamaları**
- **Exchange Tanımlama**: Hem üretici hem de tüketici, "direct_logs" adında bir direct exchange tanımlar.

- **Yönlendirme Anahtarı Kullanımı**: Üretici, mesajları "Error", "Warning", veya "Info" gibi belirli yönlendirme anahtarları ile gönderir. Tüketiciler, ilgilendikleri yönlendirme anahtarları ile değişime bağlanarak yalnızca bu anahtarlarla eşleşen mesajları alır.

- **Kuyruk Bağlama**: Tüketici, her bir yönlendirme anahtarı için kuyrukları exchange'e bağlar. Bu, direct exchange'in belirli mesajları doğru kuyruklara yönlendirmesini sağlar.

Direct exchange, mesajların hassas bir şekilde belirli tüketicilere veya hizmetlere yönlendirilmesi gerektiği senaryolar için ideal bir çözümdür. Mesajların doğrudan belirli hedeflere iletilmesi gerektiğinde, direct exchange kullanarak bu işlemi etkin bir şekilde yönetebilirsiniz.

<br><br>

**Topic Exchange**, RabbitMQ'da bir tür değişim (exchange) modelidir ve mesajların yönlendirme anahtarının (routing key) belirli bir desenle eşleşen kuyruklara yönlendirilmesini sağlar. Topic exchange, mesajların daha esnek bir şekilde yönlendirilmesine olanak tanır ve karmaşık yönlendirme senaryolarında kullanılabilir.

**Topic Exchange Özellikleri**
- **Yönlendirme Anahtarı (Routing Key)**: Mesajların gönderildiği yönlendirme anahtarı, genellikle nokta (.) ile ayrılmış kelimelerden oluşur. Örneğin, logs.error veya user.info.update.

- **Desen Eşleşmesi**: Kuyruklar, belirli bir desenle (* ve # joker karakterlerini kullanarak) topic exchange'e bağlanır. * karakteri, tam olarak bir kelime ile eşleşir. # karakteri, sıfır veya daha fazla kelime ile eşleşir. 

- **Uygulama Senaryoları**: Tipik olarak, hata ayıklama ve loglama gibi belirli mesajların belirli tüketicilere veya hizmetlere yönlendirilmesi gereken senaryolarda kullanılır.
  
  **Örnek Açıklamaları**
- **Exchange Tanımlama**: Hem üretici hem de tüketici, topic_logs adında bir topic exchange tanımlar.

- **Yönlendirme Anahtarı Kullanımı**: Üretici, mesajları belirli bir yönlendirme anahtarı ile gönderir. Bu anahtar, kuyrukların bağlı olduğu desenlerle eşleştiğinde, mesajlar ilgili kuyruklara iletilir.

- **Joker Karakterler** : "logs.*.Critical" deseni, "logs.Error.Critical" veya "logs.Warning.Critical" gibi tam iki kelimeden sonra critical ile biten anahtarlarla eşleşir.
- **Kuyruk Bağlama**: Tüketici, ilgili desenlerle eşleşen mesajları almak için kuyrukları exchange'e bağlar.

  Topic Exchange, RabbitMQ'da mesajların daha esnek ve dinamik bir şekilde yönlendirilmesini sağlar, bu da uygulama mimarisini daha modüler ve ölçeklenebilir hale getirir.
