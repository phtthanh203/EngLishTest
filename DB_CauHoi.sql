create database DB_CauHoi;
use DB_CauHoi

CREATE TABLE Questions (
    Id INT PRIMARY KEY IDENTITY,
    Content NVARCHAR(255),
    Answer1 NVARCHAR(100),
    Answer2 NVARCHAR(100),
    Answer3 NVARCHAR(100),
    Answer4 NVARCHAR(100),
    CorrectAnswerIndex INT
);

Alter table questions
Add Language NVARCHAR(100);
Alter table questions
Add level NVARCHAR(100);



 

select * from Questions;

truncate table questions;

INSERT INTO Questions (Content, Answer1, Answer2, Answer3, Answer4, CorrectAnswerIndex, Language, Level) VALUES
(N'What is the capital of Canada?', N'Toronto', N'Ottawa', N'Vancouver', N'Montreal', 1, N'English', N'hard'),
(N'Which planet has the most moons?', N'Mars', N'Saturn', N'Jupiter', N'Uranus', 2, N'English', N'hard'),
(N'Who developed the theory of relativity?', N'Isaac Newton', N'Albert Einstein', N'Galileo Galilei', N'Stephen Hawking', 1, N'English', N'hard'),
(N'What is the largest organ in the human body?', N'Liver', N'Skin', N'Lungs', N'Heart', 1, N'English', N'hard'),
(N'Which language has the most native speakers?', N'English', N'Spanish', N'Mandarin Chinese', N'Hindi', 2, N'English', N'hard');

INSERT INTO Questions (Content, Answer1, Answer2, Answer3, Answer4, CorrectAnswerIndex, Language, Level) VALUES
(N'What color is the sky on a clear day?', N'Blue', N'Green', N'Red', N'Black', 0, N'English', N'easy'),
(N'How many days are there in a week?', N'5', N'6', N'7', N'8', 2, N'English', N'easy'),
(N'Which animal says "meow"?', N'Dog', N'Cat', N'Cow', N'Duck', 1, N'English', N'easy'),
(N'How many legs does a spider have?', N'6', N'8', N'10', N'12', 1, N'English', N'easy'),
(N'What is 2 + 2?', N'3', N'4', N'5', N'6', 1, N'English', N'easy');

INSERT INTO Questions (Content, Answer1, Answer2, Answer3, Answer4, CorrectAnswerIndex, Language, Level) VALUES
(N'Đỉnh núi cao nhất Việt Nam là gì?', N'Fansipan', N'Ba Vì', N'Hoàng Liên Sơn', N'Tây Côn Lĩnh', 0, N'Vietnamese', N'hard'),
(N'Năm bao nhiêu diễn ra chiến dịch Điện Biên Phủ?', N'1950', N'1954', N'1960', N'1945', 1, N'Vietnamese', N'hard'),
(N'Nhà thơ nào được mệnh danh là "ông hoàng thơ tình"?', N'Xuân Diệu', N'Hàn Mặc Tử', N'Nguyễn Du', N'Tố Hữu', 0, N'Vietnamese', N'hard'),
(N'Tác phẩm "Truyện Kiều" có bao nhiêu câu?', N'3254', N'3456', N'3256', N'3645', 2, N'Vietnamese', N'hard'),
(N'Hợp chất nào tạo nên khí gas dùng trong bếp?', N'CO2', N'CH4', N'O2', N'N2', 1, N'Vietnamese', N'hard');

INSERT INTO Questions (Content, Answer1, Answer2, Answer3, Answer4, CorrectAnswerIndex, Language, Level) VALUES
(N'Việt Nam có bao nhiêu mùa trong năm?', N'2', N'3', N'4', N'5', 2, N'Vietnamese', N'easy'),
(N'Trẻ em thường học lớp mấy đầu tiên?', N'Lớp 1', N'Lớp 2', N'Lớp 3', N'Mẫu giáo', 0, N'Vietnamese', N'easy'),
(N'Màu của lá cây là gì?', N'Xanh', N'Đỏ', N'Tím', N'Vàng', 0, N'Vietnamese', N'easy'),
(N'Trong một ngày có bao nhiêu giờ?', N'12', N'24', N'60', N'100', 1, N'Vietnamese', N'easy'),
(N'Ngày Tết Việt Nam thường rơi vào tháng mấy?', N'Tháng 1 âm lịch', N'Tháng 3', N'Tháng 7', N'Tháng 12 dương lịch', 0, N'Vietnamese', N'easy');


