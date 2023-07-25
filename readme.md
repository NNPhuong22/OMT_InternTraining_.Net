# comment reviews

tìm text bắt đầu bằng dunp

                        //dunp: ...

Là các yêu cầu viết thêm, hoặc cần giải thích, có thể comment ngay phía dưới lời giải thích rồi , commit push lên git khi xong từng phần

                        Khi commit cho từng reviews cần phải có msg mô tả có ý nghĩa cho lần commit đó, không được phép ghi cụt lủn: update, add , ... những từ hoặc câu ko mang ý nghĩa j cho mỗi lần commit và push liên quan source change.

# bài làm về tư duy thuật toán:



Lên trên link pdf được share tìm các bài sau: 111, 112 ,134 (tự viết hàm không dùng thư viện sẵn),  155, 233, 384, 407 ( tự viết hàm sort ko xài thư viện sẵn), 449

                        https://kidsonlineeduvn-my.sharepoint.com/:b:/g/personal/dunp_omt_vn/Ec8dPSurADxNjNatQW0HnhQBnJXCkJ3FHvH_I2gXb5L4ig?e=nNxCS1

Đều tự viết hàm và không dùng thư viện sẵn.  nếu được tìm hàm thư viện sẵn viết so sánh tốc độ chạy của hàm tự viết và hàm  của thư viện. Vd dùng Stopwatch để đo

                            var sw= Stopwatch.startnew()
                            hamtuviet()
                            sw.stop()
                            console writeline sw.elpased

                            var sw= Stopwatch.startnew()
                            ham_tu_thu_vien_san()
                            sw.stop()
                            console writeline sw.elpased

                            