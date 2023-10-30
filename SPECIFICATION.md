---
category: project
project: SSC
---

- [ ] create User stories
- [ ] create Job stories
- [ ] create tasks

# ENTITIES

### Contract - Договор на выполнение работ
- Включает в себя описание работ, что должны быть выполнены для компании-клиента.
- Содержит информацию о сумме за выполняемые работы.
- Включает в себя реквизиты компании клиента.
- Содержит контакты лица, подписывающего контракт от имени компании клиента.
- Содержит информацию о статусе контракта:
  не подписан, подписан, отменен.

### Order (заявка) 
- Включает в себя перечень документов которые должны быть выполнены.
- Содержит информацию о заказчике, составлен ли договор на данную работу, подписан ли договор на данную работу, все ли документы выполнены, все ли документы одобрены.
- Информацию о статусе контракта: 
  не подписан, подписан, подписан, отменен.
  - Информацию о статусе заявки: 
  не закрыта, закрыта, отменена.
  
### Document
- Документ имеет свой порядковый номер, который включает в себя номер заявки.
- За документом закрепляется исполнитель.
- За документом закрепляется проверяющий документа.
- Содержит информацию о статусе документа:   
  разработчик не назначен , разработчик назанчен, в работе, на проверке, редактируется, готов к отправке заказчику, согласован.
- Содержит информацию о наличии необходмой документации для разработки документа получаемой от заказчика.
  
### Invoice 
- Информация о компании-клиент
- Номер договора
- Сумма оплаты за выпоненные работы.
	 

# User story

1. Менеджеры:
    
    - Как менеджер, я хочу иметь возможность войти в систему, чтобы получить доступ ко всем разделам сайта.
    - Как менеджер, я хочу иметь возможность создавать новые заявки, чтобы инициировать работу по сюрвею.
    - Как менеджер, я хочу иметь возможность назначать ответственных сюрвееров для выполнения заявок.
    - Как менеджер, я хочу иметь возможность создавать и редактировать договора с клиентами.
2. Бухгалтер:
    
    - Как бухгалтер, я хочу иметь доступ ко всем разделам сайта, чтобы управлять финансовыми данными.
    - Как бухгалтер, я хочу иметь возможность создавать и редактировать договора с клиентами, чтобы обеспечивать актуальность финансовых данных.
3. Главные сюрвееры:
    
    - Как главный сюрвеер, я хочу иметь возможность создавать новые документы в рамках заявки, чтобы начать процесс сюрвея.
    - Как главный сюрвеер, я хочу иметь возможность назначать ответственных сотрудников (младших сюрвееров) для выполнения конкретных задач в заявке.
4. Младшие сюрвееры:
    
    - Как младший сюрвеер, я хочу иметь доступ ко всем разделам, кроме разделов Договора и Бухгалтерии.
    - Как младший сюрвеер, я хочу иметь возможность работать с документами и задачами, назначенными главными сюрвеерами.
5. Супер админ:
    
    - Как супер администратор, я хочу иметь полный доступ к административной панели сайта, чтобы управлять пользователями, ролями и настройками системы.
    - Как супер администратор, я хочу иметь возможность мониторить активность пользователей и обеспечивать безопасность системы.

Эти User story могут служить отправной точкой для разработки и дизайна вашего CRM-сайта для сюрвейерской компании и помочь вам определить функциональные требования для каждой категории пользователей.

# Endpoints by ROLE

Ваш API может включать следующие конечные точки (endpoints) с учетом описанных User story для разных категорий пользователей:

1. Менеджеры:
    - `POST /api/login`: Аутентификация пользователя.
    - `GET /api/requests`: Получение списка заявок.
    - `POST /api/requests`: Создание новой заявки.
    - `PUT /api/requests/{id}/assign`: Назначение ответственных сюрвееров для заявки.
    - `POST /api/contracts`: Создание нового договора.
    - `PUT /api/contracts/{id}`: Редактирование существующего договора.

2. Бухгалтер:
    - `GET /api/contracts`: Получение списка договоров.
    - `POST /api/contracts`: Создание нового договора.
    - `PUT /api/contracts/{id}`: Редактирование существующего договора.

3. Главные сюрвееры:
    - `POST /api/requests/{id}/documents`: Создание новых документов в рамках заявки.
    - `PUT /api/requests/{id}/assign`: Назначение ответственных младших сюрвееров для выполнения задач в заявке.

4. Младшие сюрвееры:
    - `GET /api/requests/{id}/documents`: Получение списка документов в заявке.
    - `PUT /api/documents/{id}`: Редактирование существующего документа.
    
1. Супер админ:
    - `GET /api/users`: Получение списка пользователей.
    - `POST /api/users`: Создание нового пользователя.
    - `PUT /api/users/{id}`: Редактирование данных пользователя.
    - `DELETE /api/users/{id}`: Удаление пользователя.
    - `GET /api/roles`: Получение списка ролей.
    - `POST /api/roles`: Создание новой роли.
    - `PUT /api/roles/{id}`: Редактирование роли.
    - `DELETE /api/roles/{id}`: Удаление роли.

Это всего лишь базовый набор конечных точек, и вы можете дополнить его в зависимости от конкретных требований и потребностей вашего проекта. Не забудьте обеспечить аутентификацию и авторизацию для разных категорий пользователей, чтобы обеспечить безопасность вашего API.

# Endpoints by Entity

Для API вашего сайта CRM для сюрвейерской компании, учитывая предложенные User story и сущности, можно предложить следующие ендпоинты:

1. Заявки:

   - `GET /api/requests`: Получение списка всех заявок.
   - `GET /api/requests/{request_id}`: Получение информации о конкретной заявке по идентификатору.
   - `POST /api/requests`: Создание новой заявки.
   - `PUT /api/requests/{request_id}`: Обновление информации о заявке.
   - `DELETE /api/requests/{request_id}`: Удаление заявки.

2. Документы в заявке:

   - `GET /api/requests/{request_id}/documents`: Получение списка документов в заявке.
   - `GET /api/requests/{request_id}/documents/{document_id}`: Получение информации о конкретном документе в заявке.
   - `POST /api/requests/{request_id}/documents`: Создание нового документа в заявке.
   - `PUT /api/requests/{request_id}/documents/{document_id}`: Обновление информации о документе в заявке.
   - `DELETE /api/requests/{request_id}/documents/{document_id}`: Удаление документа в заявке.

3. Договоры:

   - `GET /api/contracts`: Получение списка всех договоров.
   - `GET /api/contracts/{contract_id}`: Получение информации о конкретном договоре по идентификатору.
   - `POST /api/contracts`: Создание нового договора.
   - `PUT /api/contracts/{contract_id}`: Обновление информации о договоре.
   - `DELETE /api/contracts/{contract_id}`: Удаление договора.

4. Компании-клиенты:

   - `GET /api/clients`: Получение списка всех компаний-клиентов.
   - `GET /api/clients/{client_id}`: Получение информации о конкретной компании-клиенте по идентификатору.
   - `POST /api/clients`: Создание новой компании-клиента.
   - `PUT /api/clients/{client_id}`: Обновление информации о компании-клиенте.
   - `DELETE /api/clients/{client_id}`: Удаление компании-клиента.

5. Контактные лица компаний-клиентов:

   - `GET /api/clients/{client_id}/contacts`: Получение списка контактных лиц компании-клиента.
   - `GET /api/clients/{client_id}/contacts/{contact_id}`: Получение информации о конкретном контактном лице по идентификатору.
   - `POST /api/clients/{client_id}/contacts`: Создание нового контактного лица.
   - `PUT /api/clients/{client_id}/contacts/{contact_id}`: Обновление информации о контактном лице.
   - `DELETE /api/clients/{client_id}/contacts/{contact_id}`: Удаление контактного лица.

Эти ендпоинты должны позволить вам взаимодействовать с данными и выполнять операции, описанные в предложенных User story, в вашем веб-сервисе CRM.

---



# Endpoints by Service

Исходя из предложенных сервисов и сущностей в вашем проекте CRM для сюрвейерской компании, вот предложенные ендпоинты для вашего WebAPI:

1. **UserService**:

   - `POST /api/auth/login`: Аутентификация пользователя.
   - `POST /api/auth/register`: Регистрация нового пользователя.
   - `GET /api/users`: Получение списка пользователей.
   - `GET /api/users/{user_id}`: Получение информации о конкретном пользователе.
   - `PUT /api/users/{user_id}`: Обновление информации о пользователе.
   - `DELETE /api/users/{user_id}`: Удаление пользователя.

2. **RequestService**:

   - `GET /api/requests`: Получение списка всех заявок.
   - `GET /api/requests/{request_id}`: Получение информации о конкретной заявке.
   - `POST /api/requests`: Создание новой заявки.
   - `PUT /api/requests/{request_id}`: Обновление информации о заявке.
   - `DELETE /api/requests/{request_id}`: Удаление заявки.

3. **DocumentService**:

   - `GET /api/documents`: Получение списка всех документов.
   - `GET /api/documents/{document_id}`: Получение информации о конкретном документе.
   - `POST /api/documents`: Создание нового документа.
   - `PUT /api/documents/{document_id}`: Обновление информации о документе.
   - `DELETE /api/documents/{document_id}`: Удаление документа.

4. **ContractService**:

   - `GET /api/contracts`: Получение списка всех договоров.
   - `GET /api/contracts/{contract_id}`: Получение информации о конкретном договоре.
   - `POST /api/contracts`: Создание нового договора.
   - `PUT /api/contracts/{contract_id}`: Обновление информации о договоре.
   - `DELETE /api/contracts/{contract_id}`: Удаление договора.

5. **ClientService**:

   - `GET /api/clients`: Получение списка всех компаний-клиентов.
   - `GET /api/clients/{client_id}`: Получение информации о конкретной компании-клиенте.
   - `POST /api/clients`: Создание новой компании-клиента.
   - `PUT /api/clients/{client_id}`: Обновление информации о компании-клиенте.
   - `DELETE /api/clients/{client_id}`: Удаление компании-клиента.

6. **ContactService**:

   - `GET /api/clients/{client_id}/contacts`: Получение списка контактных лиц компании-клиента.
   - `GET /api/clients/{client_id}/contacts/{contact_id}`: Получение информации о конкретном контактном лице.
   - `POST /api/clients/{client_id}/contacts`: Создание нового контактного лица.
   - `PUT /api/clients/{client_id}/contacts/{contact_id}`: Обновление информации о контактном лице.
   - `DELETE /api/clients/{client_id}/contacts/{contact_id}`: Удаление контактного лица.

7. **AssignmentService**:

   - `POST /api/assignments`: Создание нового назначения для заявки или документа.
   - `PUT /api/assignments/{assignment_id}`: Обновление информации о назначении.
   - `DELETE /api/assignments/{assignment_id}`: Удаление назначения.

8. **AuditService**:

   - `GET /api/audit-logs`: Получение журнала аудита системных событий.

9. **NotificationService**:

   - `GET /api/notifications`: Получение уведомлений для текущего пользователя.
   - `POST /api/notifications`: Отправка уведомления.

10. **ReportService**:

    - `GET /api/reports`: Запрос на генерацию отчетов с различными параметрами.

11. **AuthorizationService**:

    - `POST /api/auth/token`: Запрос на получение токена для аутентификации API запросов.

12. **FileService**:

    - `POST /api/files/upload`: Загрузка файлов на сервер.
    - `GET /api/files/{file_id}`: Скачивание файла.

13. **EmailService**:

    - `POST /api/emails/send`: Отправка электронных писем.

14. **SettingsService**:

    - `GET /api/settings`: Получение настроек системы.
    - `PUT /api/settings`: Обновление настроек системы.

15. **LocalizationService**:

    - `GET /api/localization`: Получение локализованных текстов и сообщений для поддержки разных языков.

16. **SecurityService**:

    - Этот сервис может предоставлять функции безопасности, такие как шифрование и защиту от атак, но не обязательно иметь отдельные ендпоинты.

Помимо вышеперечисленных, в зависимости от конкретных требований вашего проекта, могут потребоваться дополнительные ендпоинты и сервисы.

# SERVICEs

При разделении бэкенд-части проекта на три проекта (DAL, Domain, WebAPI), сервисы обычно размещаются в папке Services проекта Domain. Вот перечень типичных сервисов, которые могут быть размещены в папке Services:

1. **UserService**: Управление пользователями, включая аутентификацию, авторизацию, управление ролями и правами доступа.

2. **RequestService**: Управление заявками, включая создание, обновление, удаление и поиск заявок.

3. **DocumentService**: Управление документами, включая создание, обновление, удаление и поиск документов.

4. **ContractService**: Управление договорами, включая создание, обновление, удаление и поиск договоров.

5. **ClientService**: Управление компаниями-клиентами, включая создание, обновление, удаление и поиск компаний-клиентов.

6. **ContactService**: Управление контактными лицами компаний-клиентов, включая создание, обновление, удаление и поиск контактных лиц.

7. **AssignmentService**: Управление назначениями и ответственными лицами для заявок и документов.

8. **AuditService**: Журналирование действий пользователей и аудит системных событий.

9. **NotificationService**: Управление уведомлениями и оповещениями пользователей о событиях в системе.

10. **ReportService**: Генерация и предоставление отчетов и статистики для пользователей.

11. **AuthorizationService**: Сервис для управления авторизацией и генерации токенов для аутентификации API запросов.

12. **FileService**: Управление файлами и хранение документов.

13. **EmailService**: Отправка электронных писем и управление уведомлениями по электронной почте.

14. **SettingsService**: Управление настройками и конфигурацией системы.

15. **LocalizationService**: Локализация текстовых сообщений и интерфейса для поддержки разных языков.

16. **SecurityService**: Меры безопасности, такие как шифрование данных, защита от атак и обработка исключений.

Это лишь примеры сервисов, которые могут потребоваться в вашем проекте CRM для сюрвейерской компании. Фактический перечень сервисов может зависеть от конкретных требований вашего проекта и бизнес-потребностей.




___
### Project SSC:
```dataview
LIST
FROM "Notes"
WHERE contains(project, "SSC")
SORT number ASC 
```