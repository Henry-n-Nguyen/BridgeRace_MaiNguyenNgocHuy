# 🟢 BridgeRace

**Bridgerace** là một dự án game 3D (Top-down) thuộc thể loại cạnh tranh sinh tồn (IO Game) được phát triển bằng Unity. Trong trò chơi, người chơi điều khiển một thực thể với mục tiêu: nhật gạch, di chuyển khéo léo xếp gạch xây cầu và trở thành người dẫn đầu bảng xếp hạng.

---

## 🎮 Tổng quan trò chơi

### Các tính năng chính:
* **Cơ chế tăng trưởng (Scaling System):** Nhân vật tự động thay đổi kích thước và tầm nhìn (Camera Zoom) dựa trên số lượng điểm (orbs) thu thập được.
* **Hệ thống AI Bots:** Các đối thủ máy có hành vi tự động tìm kiếm thức ăn và né tránh người chơi lớn hơn (Simple Steering Behaviors).
* **Vùng an toàn/Giới hạn:** Bản đồ có biên giới, buộc người chơi phải tương tác với nhau trong không gian hẹp dần.

---

## 🛠 Kỹ thuật & Giải pháp lập trình (Technical Highlights)
Dự án tập trung vào việc xử lý logic mượt mà và tối ưu hóa tài nguyên:

1.  **Physics-Based Movement:** Sử dụng `Rigidbody2D/3D` kết hợp với `AddForce` để tạo cảm giác di chuyển có quán tính, đặc trưng của các dòng game .io.
2.  **Object Pooling:** Sử dụng để quản lý các chướng ngại vật và hiệu ứng hạt (particles), giúp giảm thiểu việc `Instantiate` và `Destroy` liên tục, tránh gây giật lag do Garbage Collector.
3.  **Cinemachine:** Sử dụng `Cinemachine Framer Transposer` để xử lý camera mượt mà, tự động điều chỉnh khoảng cách (Ortho Size) khi người chơi lớn dần.
4.  **Optimization (Culling):** Chỉ xử lý logic cho các đối tượng nằm trong hoặc gần tầm nhìn của Camera để tiết kiệm CPU.
5.  **Observer Pattern:** Hệ thống UI (Điểm số, Leaderboard) đăng ký lắng nghe sự kiện từ Player, giúp tách biệt hoàn toàn logic game và logic hiển thị.

---
