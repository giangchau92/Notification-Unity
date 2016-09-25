# Notification Center for Unity

Ngắn gọn, dễ sữ dụng nhưng rất hiệu quả.

## Sữ dụng
```cs
NotificationCenter.getInstance().addEvent("GAME_DEACTIVE", callback);
```

```cs
NotificationCenter.getInstance().removeEvent("GAME_DEACTIVE", callback);
```

```cs
void callback(string eventName, object data) {
}
```

```cs
NotificationCenter.getInstance().dispatchEvent("GAME_DEACTIVE", data);
```
