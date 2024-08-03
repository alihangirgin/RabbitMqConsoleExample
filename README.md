**Fanout Exchange**, RabbitMQ'da bir tür değişim (exchange) modelidir ve mesajları doğrudan tüm bağlı kuyruklara yayınlamak için kullanılır. Bu model, bir mesajın aynı anda birden fazla kuyruğa dağıtılması gerektiğinde kullanılır ve genellikle yayınlama (broadcast) senaryoları için uygundur.

**Fanout Exchange Özellikleri**

- **Yayınlama**: Fanout exchange, bir mesaj aldığında, bağlı olduğu tüm kuyruklara mesajı kopyalar ve gönderir. Routing key dikkate alınmaz, bu nedenle mesajlar tüm kuyruklara gönderilir.

- **Yönlendirme Anahtarı (Routing Key)**: Fanout exchange, yönlendirme anahtarını (routing key) dikkate almaz. Yani, üretici mesaj gönderirken herhangi bir yönlendirme anahtarı belirtse bile bu anahtar dikkate alınmaz.

- **Uygulama Senaryoları**: Genellikle, bildirimler, yayınlar veya güncellemelerin geniş bir kitleye dağıtılması gerektiğinde kullanılır. Örneğin, bir chat uygulamasında mesajların tüm kullanıcılar arasında paylaşılması için fanout exchange kullanılabilir.

**Örnek Açıklamaları**
- **Exchange Tanımlama**: Hem üretici hem de tüketici, "logsFanout" adında bir fanout exchange tanımlar. Tüketiciler, mesajları almak için bu exchange'e bağlanırlar.

- **Geçici Kuyruk**: Tüketici, fanout exchange'den mesajları almak için bir geçici kuyruk oluşturur (channel.QueueDeclare().QueueName). Bu kuyruk, tüketici bağlantısını kapattığında otomatik olarak silinir.

- **Kuyruk Bağlama**: Tüketici, kuyrukları fanout exchange'e bağlamak için QueueBind yöntemini kullanır. Bu işlem, exchange'den kuyruklara mesajların yönlendirilmesini sağlar.

- **Mesaj Yayını**: Üretici, mesajları exchange'e gönderir. Fanout exchange, bu mesajları bağlı tüm kuyruklara dağıtır.

  Fanout exchange, bir mesajın birden fazla hedefe ulaştırılması gerektiği durumlar için ideal bir çözümdür. Bu yapı, mesajların geniş kitlelere hızlı bir şekilde dağıtılmasını sağlar.
