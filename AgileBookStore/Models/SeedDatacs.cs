using AgileBookStore.Data;
using AgileBookStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AgileBookStore.Models
{
	public static class SeedData
	{
		public static void EnsurePopulated(IApplicationBuilder app)
		{
			AgileBookStoreContext context = app.ApplicationServices
				.CreateScope()
				.ServiceProvider
				.GetRequiredService<AgileBookStoreContext>();
			if (!context.Database.GetPendingMigrations().Any())
			{
				context.Database.Migrate();
			}
			if (!context.Categories.Any())
			{
				context.Categories.AddRange(
					new Category
					{
						Name = "Fantasy"
					},
					new Category
					{
						Name = "Adventure"
					},
					new Category
					{
						Name = "Mystery"
					},
					new Category
					{
						Name = "Dark"
					},
					new Category
					{
						Name = "Romance"
					},
					new Category
					{
						Name = "School"
					},
					new Category
					{
						Name = "Slice of Life"
					},
					new Category
					{
						Name = "Tragedy"
					},
					new Category
					{
						Name = "Chill"
					},
					new Category
					{
						Name = "Learning"
					},
					new Category
					{
						Name = "Toys"
					},
					new Category
					{
						Name = "Accessory"
					},
					new Category
					{
						Name = "Psychology"
					},
					new Category
					{
						Name = "Deep work"
					}
					);
				context.SaveChanges();
			}
			if (!context.Products.Any())
			{
				for (int i = 1; i <= 8; i++)
				{
					context.Products.AddRange(
						new Product
						{
							NameProduct = "Lý Thuyết Trò Chơi",
							Price = 145000,
							Categories = context.Categories.Where(c => c.Name == "Tragedy" || c.Name == "Learning").ToList(),
							Description = "LÝ THUYẾT TRÒ CHƠI\r\n\r\nĐời người giống như trò chơi, mỗi bước đều phải cân nhắc xem đi như thế nào, đi về đâu, phải kết hợp nhiều yếu tố lại chúng ta mới có thể đưa ra được lựa chọn. Mà trong quá trình chọn lựa này các yếu tố khiến ta phải cân nhắc và những đường đi khác nhau sẽ ảnh hưởng trực tiếp đến kết quả.\r\n\r\nCuốn sách Lý thuyết trò chơi là bách khoa toàn thư về tâm lý học, về tẩy não và chống lại tẩy não, thao túng và chống lại thao túng, thống trị và chống lại thống trị. Cuốn sách giới thiệu công thức chiến thắng cho những “trò chơi” đấu trí giữa người với người trong cuộc sống hằng ngày; phân tách các khái niệm lý thuyết trò chơi vốn mơ hồ trở thành ngôn ngữ dễ hiểu và kết nối liền mạch với nghệ thuật tâm lý học; cho phép bạn nắm vững những bí ẩn của trò chơi tâm lý trong thời gian ngắn nhất.\r\n\r\nNhững kỹ năng trong Lý thuyết trò chơi có thể giúp chúng ta đọc thấu hoạt động tâm lý người khác, và từ đó chiếm thế chủ động trong trò chơi đấu trí giữa những người xung quanh.\r\n\r\nNhững trích dẫn hay:\r\n- Nếu coi một ván chơi như một trò chơi, mà trò chơi luôn luôn có thắng thua. Một bên thắng thì đồng nghĩa bên kia thất bại.\r\n- Đằng sau những người chiến thắng lẫy lừng đều che giấu một nỗi khổ tâm và chua xót của kẻ thua cuộc.\r\n- Hãy coi xã hội này như một ván cờ, mà mỗi chúng ta đều là những kỳ thủ. Từng đường đi nước bước của ta đều tương ứng với việc đặt từng con cờ. Một kỳ thủ tinh tường cẩn thận sẽ không hấp tấp đánh cờ, họ thường thông qua việc suy đoán lẫn nhau, thậm chí tính kế để từng bước đi đều khống chế đối phương cho đến khi giành được thắng lợi cuối cùng. Mà thuyết trò chơi chính là cuốn sách giáo khoa dạy những kỳ thủ chúng ta nên đánh cờ như thế nào.\r\n\r\nGiá sản phẩm trên Tiki đã bao gồm thuế theo luật hiện hành. Bên cạnh đó, tuỳ vào loại sản phẩm, hình thức và địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như phí vận chuyển, phụ phí hàng cồng kềnh, thuế nhập khẩu (đối với đơn hàng giao từ nước ngoài có giá trị trên 1 triệu đồng).....",
							imageurl1 = "https://salt.tikicdn.com/cache/750x750/ts/product/8a/b6/ba/1d95b88597f28e42d8ca91e3b3ff600f.jpg.webp",
							imageurl2 = "https://salt.tikicdn.com/cache/750x750/ts/product/aa/43/76/f6c2532e1d8780c763efc27403ddc377.jpg.webp",
							imageurl3 = "https://salt.tikicdn.com/cache/750x750/ts/product/a1/94/b7/843f590d2bcdd9ef7fa028ce54010a40.jpg.webp"
						}
					);
				}
				for (int i = 1; i <= 8; i++)
				{
					context.Products.AddRange(
						new Product
						{
							NameProduct = "How Psychology Works - Hiểu Hết Về Tâm Lý Học",
							Price = 178000,
							Categories = context.Categories.Where(c => c.Name == "Psychology" || c.Name == "Learning").ToList(),
							Description = "MỘT TRONG NHỮNG CUỐN SÁCH MỞ KHÓA HỮU ÍCH NHẤT VỀ TƯ DUY, KÝ ỨC VÀ CẢM XÚC CỦA CON NGƯỜI!\r\n\r\nÁm sợ là gì, ám sợ có thực sự đáng sợ không? Rối loạn tâm lý là gì, làm thế nào để thoát khỏi tình trạng suy nhược và xáo trộn đó? Trầm cảm là gì, vì sao con người hiện đại thường xuyên gặp và chống chọi với tình trạng u uất, mệt mỏi và tuyệt vọng này?\r\n\r\nTìm hiểu về các vấn đề tâm trí của con người luôn đầy sức hấp dẫn và lôi cuốn, vì vậy mà tâm lý học ra đời, hình thành và phát triển rất nhiều các học thuyết và trường phái. Cuốn sách này dẫn dắt bạn đọc qua hành trình tìm hiểu các học thuyết và trường phái đó, về cách các nhà tâm lý diễn giải hành xử và tâm trí con người. Tại sao chúng ta có những hành vi, suy nghĩ và cảm xúc như vậy, chúng diễn ra và kết thúc như thế nào, chúng ảnh hưởng lâu dài, gián đoạn hay ngắn ngủỉ đến đời sống của chúng ta ra sao, làm thế nào để chúng ta thoát khỏi những tác động tiêu cực của chúng?\r\n\r\nCuốn sách có cấu trúc khoa học, trình bày dễ hiểu, súc tích, thiết kế và minh họa đẹp mắt này sẽ mang đến cho bạn những hiểu biết về các học thuyết tâm lý và các phương pháp trị liệu, từ các vấn đề cá nhân đến những ứng dụng thực tế.\r\n\r\n\r\nGiá sản phẩm trên Tiki đã bao gồm thuế theo luật hiện hành. Bên cạnh đó, tuỳ vào loại sản phẩm, hình thức và địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như phí vận chuyển, phụ phí hàng cồng kềnh, thuế nhập khẩu (đối với đơn hàng giao từ nước ngoài có giá trị trên 1 triệu đồng).....",
							imageurl1 = "https://salt.tikicdn.com/cache/750x750/ts/product/2b/84/ff/cb34637573525a998596b58d6939411e.jpg.webp",
							imageurl2 = "https://salt.tikicdn.com/cache/750x750/ts/product/73/c8/30/17d4f810b426d93fb39b7156e23c9a07.jpeg.webp",
							imageurl3 = "https://salt.tikicdn.com/cache/750x750/ts/product/a1/94/b7/843f590d2bcdd9ef7fa028ce54010a40.jpg.webp"
						}
					);
				}
				for (int i = 1; i <= 8; i++)
				{
					context.Products.AddRange(
						new Product
						{
							NameProduct = "Không Phải Sói Nhưng Cũng Đừng Là Cừu ",
							Price = 178000,
							Categories = context.Categories.Where(c => c.Name == "Psychology" || c.Name == "Tragedy" || c.Name == "Deep work" || c.Name == "Chill").ToList(),
							Description = "SÓI VÀ CỪU - BẠN KHÔNG TỐT NHƯ BẠN NGHĨ ĐÂU!\r\n\r\nLàn ranh của việc ngây thơ hay xấu xa đôi khi mỏng manh hơn bạn nghĩ.\r\n\r\nBạn làm một việc mà mình cho là đúng, kết quả lại bị mọi người khiển trách.\r\n\r\nBạn ủng hộ một quan điểm của ai đó, và số đông khác lại ủng hộ một quan điểm trái chiều.\r\n\r\nRốt cuộc thì bạn sai hay họ sai?\r\n\r\nCuốn sách “Không phải sói nhưng cũng đừng là cừu” đến từ tác giả Lê Bảo Ngọc sẽ giúp bạn hiểu rõ hơn những khía cạnh sắc sảo phía sau những nhận định đúng, sai đơn thuần của mỗi người.\r\n\r\nNhững câu hỏi đầy tính tranh cãi như “Cứu người hay cứu chó?”, “Một kẻ thô lỗ trong lớp vỏ “thẳng tính” khác với người EQ thấp như thế nào?”, “Vì sao một bộ phận nữ giới lại victim blaming đối với nạn nhân bị xâm hại?”, được tác giả đưa ra trong “Không phải sói nhưng cũng đừng là cừu”. Bằng từng chương sách của mình, tác giả vạch rõ cho bạn rằng “thật sự thế nào mới là người tốt”, ngây thơ và xấu xa có ranh giới rõ ràng như thế không, rốt cuộc bạn có là người tốt như mình vẫn luôn nghĩ?\r\n\r\nTrong thời đại mà mọi thứ đều rất chóng vánh này, ranh giới giữa tốt và xấu, đúng và sai đôi lúc là không tồn tại.\r\n\r\nCái tốt mà chúng ta nghĩ, hóa ra lại là xấu trong mắt kẻ khác.\r\n\r\nCái đúng ở thời điểm này, đến một thời điểm khác lại trở thành sai.\r\n\r\nTốt đẹp hay xấu xa, thật khó phân định.\r\n\r\nCuốn sách “Không phải sói nhưng cũng đừng là cừu” của tác giả Lê Bảo Ngọc - admin Tâm Lý Học Tổ Kén đồng thời là Giám đốc Trung tâm Pháp Luật và Văn hóa sẽ là câu trả lời thấu suốt và khiến bạn phải đặt ra câu hỏi cho lối tư duy bấy lâu bạn luôn nghĩ là đúng. Bạn sẽ là người giải phóng chính mình, khỏi gông xiềng của định kiến, quy chuẩn cũ kĩ vốn được thiết lập lên để mang lại lợi ích cho kẻ khác. Và bạn sẽ không còn phải lăn tăn giữa tốt và xấu, sói hay cừu, vì điều đó là không quan trọng. Bạn sẽ tìm được chính mình và muốn là chính mình sau từng trang sách của “Không phải sói mà cũng đừng là cừu\"\r\n\r\nKhông phải sói, cũng đừng là cừu - Cuốn sách đập tan những định kiến cũ kỹ, kiến tạo tư duy và giúp bạn xây dựng lại chính mình!\r\n\r\nGiá sản phẩm trên Tiki đã bao gồm thuế theo luật hiện hành. Bên cạnh đó, tuỳ vào loại sản phẩm, hình thức và địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như phí vận chuyển, phụ phí hàng cồng kềnh, thuế nhập khẩu (đối với đơn hàng giao từ nước ngoài có giá trị trên 1 triệu đồng).....",
							imageurl1 = "https://salt.tikicdn.com/cache/750x750/ts/product/09/2b/e4/e220a9a28a35a7c6ed3336e89c09178b.jpg.webp",
							imageurl2 = "https://salt.tikicdn.com/cache/750x750/ts/product/5b/96/23/348b84ca8e0d0b49bf9c8d9595336e69.jpg.webp",
							imageurl3 = "https://salt.tikicdn.com/cache/750x750/ts/product/c1/ac/74/a96cad7ead5fe6ec3ff205e167855534.png.webp"
						}
					);
				}
				for (int i = 1; i <= 8; i++)
				{
					context.Products.AddRange(
						new Product
						{
							NameProduct = "Nói Chuyện Là Bản Năng, Giữ Miệng Là Tu Dưỡng, Im Lặng Là Trí Tuệ",
							Price = 178000,
							Categories = context.Categories.Where(c => c.Name == "Psychology" || c.Name == "Tragedy" || c.Name == "Fantasy" || c.Name == "Slice of Life").ToList(),
							Description = "Tuân Tử nói: “Nói năng hợp lý, đó gọi là hiểu biết; im lặng đúng lúc, đó cũng là hiểu biết”. Ngôn ngữ là thứ có thể thể hiện rõ nhất mức độ tu dưỡng của một người, nói năng hợp lý là một loại trí tuệ, mà im lặng đúng lúc cũng là một loại trí tuệ. Nếu một người không biết giữ miệng, nói mà không suy nghĩ, nghĩ gì nói nấy, tất nhiên rất dễ khiến người khác chán ghét.\r\n\r\nNội dung quyển sách này xoay quanh hai vấn đề đó là “biết cách nói chuyện” và “biết giữ miệng”, thông qua 12 chương sách nói rõ cách nói chuyện với những người khác nhau, cách nói chuyện trong những trường hợp khác nhau, làm thế nào để nắm vững những kỹ năng và chừng mực để nói chuyện cho khôn khéo, những người không giỏi ăn nói làm cách nào mới có thể nói được những lời thích hợp với đúng người và đúng thời điểm, để có thể ứng phó với những trường hợp khác nhau trong giao tiếp.\r\n\r\nNgười biết nói chuyện, ẩn sau con người họ là lòng tốt đã khắc sâu vào xương tủy, là sự tôn trọng đến từ việc đặt mình vào vị trí của người khác, là trí tuệ sâu sắc, độc đáo và lòng kiên nhẫn không ngại phiền hà. Họ chưa hẳn là những người giỏi ăn nói, nhưng mỗi khi nói đều làm người khác như được tắm trong gió xuân, vừa mở miệng là đã toát lên khí chất hơn người.\r\n\r\nNgười biết giữ miệng, bất kể trong trường hợp nào, họ đều có thể lập tức nhìn thấu cảm xúc của người khác, quan tâm đến cảm giác của đối phương, nói năng có chừng mực, làm gì cũng chừa lại đường lui cho mình và người khác. Vừa mở miệng là có thể làm yên lòng người khác, tự nhiên đi tới đâu cũng sẽ được chào đón.\r\n\r\nBiết giữ im lặng thì cuộc sống sẽ dễ chịu hơn, học cách giữ miệng thì cuộc đời này sẽ không còn điều gì phải hối hận. Điều không nên nói thì không nói, điều không nên hỏi thì không hỏi, hiểu ý mà không vạch trần, nhìn thấu mà không nói ra, đó là bậc đại trí.\r\n\r\nĐôi nét về tác giả:\r\n\r\nTrương Tiếu Hằng là một tác giả đồng thời là một nhà sản xuất. Ông từng là một nhân viên bình thường, từng làm bán hàng rồi tự mở công ty, ông đã đi nhiều nơi, đọc sách, sáng tác, tìm hiểu về cuộc sống. Vốn sống phong phú, bút pháp tinh tế cùng lối viết đi thẳng vào trọng tâm luôn mang lại cho độc giả cảm giác sảng khoái khi đọc tác phẩm của ông. Một số tác phẩm của ông đã được xuất bản như “Khoa triết học Đại học Bắc Kinh”, “EQ cao chính là biết cách nói chuyện”.\r\n\r\nGiá sản phẩm trên Tiki đã bao gồm thuế theo luật hiện hành. Bên cạnh đó, tuỳ vào loại sản phẩm, hình thức và địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như phí vận chuyển, phụ phí hàng cồng kềnh, thuế nhập khẩu (đối với đơn hàng giao từ nước ngoài có giá trị trên 1 triệu đồng).....",
							imageurl1 = "https://salt.tikicdn.com/cache/750x750/ts/product/09/2b/e4/e220a9a28a35a7c6ed3336e89c09178b.jpg.webp",
							imageurl2 = "https://salt.tikicdn.com/cache/750x750/ts/product/44/72/e7/af7fe845d6f1065bffb4e5fa43d72f6d.jpg.webp",
							imageurl3 = "https://salt.tikicdn.com/cache/750x750/ts/product/44/72/e7/af7fe845d6f1065bffb4e5fa43d72f6d.jpg.webp"
						}
					);
				}
				for (int i = 1; i <= 8; i++)
				{
					context.Products.AddRange(
						new Product
						{
							NameProduct = "Yêu Mình Trước Đã, Yêu Đời Để Sau",
							Price = 178000,
							Categories = context.Categories.Where(c => c.Name == "Psychology" || c.Name == "Tragedy" || c.Name == "Fantasy" || c.Name == "Slice of Life").ToList(),
							Description = "Tình yêu bản thân là sự cân bằng giữa việc chấp nhận con người thật của chính mình, song song với việc biết rằng mình xứng đáng với những điều tốt đẹp hon, và hành động theo kim chỉ nam đó.\r\n\r\nTác giả truyền cảm hứng\r\n\r\nYêu mình trước đã, yêu đời để sau được chấp bút bởi Vex King - một nhà văn, một huấn luyện viên tinh thần và một doanh nhân – người đã trải qua vô vàn thử thách trong quá trình trưởng thành. Anh từng sống dưới đáy của cuộc đời khi cha anh qua đời từ khi anh còn là một đứa trẻ, từng trải qua thời gian sống vô gia cư và lớn lên trong một khu phố nhiều tệ nạn. Anh cũng thường xuyên bị bắt nạt do nạn phân biệt chủng tộc.\r\n\r\nTuy nhiên, Vex vẫn vươn lên mạnh mẽ và thành công trong cuộc sống. Tài khoản Instagram cá nhân của anh (@vexking) đã trở thành nguồn cảm hứng của hàng ngàn người trẻ. Anh là người bắt đầu phong trào \"Good Vibes Only #GVO\" để giúp người khác sử dụng sức mạnh của sự tích cực để biến đổi bản thân và cuộc sống của họ thành một điều gì đó vĩ đại hơn.\r\n\r\nCuốn sách cần một sự kết hợp qua lại giữa nội dung cuốn sách và cam kết của người đọc\r\n\r\n\"Yêu mình trước đã, yêu đời để sau\" đòi hỏi bạn phải cam kết ngay bây giờ để trở thành phiên bản tốt hơn, vĩ đại hơn của chính mình. Mục tiêu của nó là giúp bạn trở nên tốt hơn so với chính bạn ngày hôm qua, mỗi ngày, trong mọi lĩnh vực, và trong suốt phần đời còn lại của bạn.\r\n\r\nSự vĩ đại không phải là khái niệm một chiều. Mặc dù xét về mặt chủ quan, hầu hết mọi người sẽ liên tưởng khái niệm này với việc có một khả năng đặc biệt, có nhiều tiền hoặc của cải vật chất, quyền lực hoặc địa vị, và những thành tựu to lớn mà họ đã đạt được qua nhiều quá trình nỗ lực, đấu tranh. Nhưng sự vĩ đại thực sự sâu sắc hơn như vậy rất nhiều. Sự vĩ đại không thể tồn tại nếu thiếu đi mục đích, tình yêu, lòng vị tha, sự khiêm tốn, sự trân trọng, lòng nhân hậu, và tất nhiên – đặc ân lớn nhất mà con người được ban tặng – niềm hạnh phúc.\r\n\r\nBạn xứng đáng với một cuộc sống tốt đẹp hơn và cuốn sách này sẽ giúp bạn tạo ra cuộc sống đó !\r\n\r\nGiá sản phẩm trên Tiki đã bao gồm thuế theo luật hiện hành. Bên cạnh đó, tuỳ vào loại sản phẩm, hình thức và địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như phí vận chuyển, phụ phí hàng cồng kềnh, thuế nhập khẩu (đối với đơn hàng giao từ nước ngoài có giá trị trên 1 triệu đồng).....",
							imageurl1 = "https://salt.tikicdn.com/cache/750x750/ts/product/09/2b/e4/e220a9a28a35a7c6ed3336e89c09178b.jpg.webp",
							imageurl2 = "https://salt.tikicdn.com/cache/750x750/ts/product/ed/1e/6e/e7cc2a5c73f7a4206a85a66f3bfa3a09.jpg.webp",
							imageurl3 = "https://salt.tikicdn.com/cache/750x750/ts/product/ed/1e/6e/e7cc2a5c73f7a4206a85a66f3bfa3a09.jpg.webp"
						}
					);
				}
				context.SaveChanges();
			}
		}
	}
}
