INSERT INTO [dbo].[EmailTemplates]	([Title], [Body])
     VALUES
           (N'Premium',
			N'<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
			<html xmlns="http://www.w3.org/1999/xhtml" xmlns="http://www.w3.org/1999/xhtml" style="font-family: ''Helvetica Neue'', Helvetica, Arial, sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;">
			<head>
			<meta name="viewport" content="width=device-width" />
			<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
			<title>Billing e.g. invoices and receipts</title>

			<style>img {
			max-width: 100%;
			}
			body {
			-webkit-font-smoothing: antialiased; -webkit-text-size-adjust: none; width: 100% !important; height: 100%; line-height: 1.6em;
			}
			body {
			background-color: #f6f6f6;
			}
			@@media only screen and (max-width: 640px) {
			  body {
				padding: 0 !important;
			  }
			  h1 {
				font-weight: 800 !important; margin: 20px 0 5px !important;
			  }
			  h2 {
				font-weight: 800 !important; margin: 20px 0 5px !important;
			  }
			  h3 {
				font-weight: 800 !important; margin: 20px 0 5px !important;
			  }
			  h4 {
				font-weight: 800 !important; margin: 20px 0 5px !important;
			  }
			  h1 {
				font-size: 22px !important;
			  }
			  h2 {
				font-size: 18px !important;
			  }
			  h3 {
				font-size: 16px !important;
			  }
			  .container {
				padding: 0 !important; width: 100% !important;
			  }
			  .content {
				padding: 0 !important;
			  }
			  .content-wrap {
				padding: 10px !important;
			  }
			  .invoice {
				width: 100% !important;
			  }
			}
			</style></head>

			<body itemscope="" itemtype="http://schema.org/EmailMessage" style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; -webkit-font-smoothing: antialiased; -webkit-text-size-adjust: none; width: 100% !important; height: 100%; line-height: 1.6em; margin: 0;" bgcolor="#f6f6f6">

			<table style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; width: 100%; margin: 0;" bgcolor="#f6f6f6"><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;" valign="top"></td>
					<td width="600" style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; display: block !important; max-width: 600px !important; clear: both !important; margin: 0 auto;" valign="top">
						<div style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; max-width: 600px; display: block; margin: 0 auto; padding: 20px;">
							<table width="100%" cellpadding="0" cellspacing="0" style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; border-radius: 3px; margin: 0; border: 1px solid #e9e9e9;" bgcolor="#fff"><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0; padding: 20px;" align="center" valign="top">
										<table width="100%" cellpadding="0" cellspacing="0" style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0 0 20px;" valign="top">
													<h1 style="font-family: ''Helvetica Neue'',Helvetica,Arial,''Lucida Grande'',sans-serif; box-sizing: border-box; font-size: 32px; color: #000; line-height: 1.2em; font-weight: 500; margin: 40px 0 0;" align="center">Оплата в размере @Model.Premium.Sum <br> @Model.Premium.Currency успешно проведена</h1>
												</td>
											</tr><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0 0 20px;" valign="top">
													<h2 style="font-family: ''Helvetica Neue'',Helvetica,Arial,''Lucida Grande'',sans-serif; box-sizing: border-box; font-size: 24px; color: #000; line-height: 1.2em; font-weight: 400; margin: 40px 0 0;" align="center">Спасибо, что пользуетесь сервисом ROCKET</h2>
												</td>
											</tr><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0 0 20px;" align="center" valign="top">
													<table style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; text-align: left; width: 80%; margin: 40px auto;"><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0; padding: 5px 0;" valign="top">@Model.Premium.Receiver.FirstName @Model.Premium.Receiver.LastName<br style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;" /><br style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;" />@DateTime.Now</td>
														</tr><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0; padding: 5px 0;" valign="top">
																<table cellpadding="0" cellspacing="0" style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; width: 100%; margin: 0;"><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; border-top-width: 1px; border-top-color: #eee; border-top-style: solid; margin: 0; padding: 5px 0;" valign="top">Оплата премиум аккаунта</td>
																		<td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; border-top-width: 1px; border-top-color: #eee; border-top-style: solid; margin: 0; padding: 5px 0;" align="right" valign="top">@Model.Premium.Sum @Model.Premium.Currency</td>
																	</tr></table></td>
														</tr></table></td>
											</tr><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0 0 20px;" align="center" valign="top">
													<a href="http://www.mailgun.com" style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; color: #348eda; text-decoration: underline; margin: 0;">Перейти на главную страницу ROCKET</a>
												</td>
											</tr><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0 0 20px;" align="center" valign="top">
							  ул. Скрыганова, 14, 5-й этаж, г. Минск, Республика Беларусь                 
												</td>
											</tr></table></td>
								</tr></table><div style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; width: 100%; clear: both; color: #999; margin: 0; padding: 20px;">					
					</td>
					<td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;" valign="top"></td>
				</tr></table></body>
			</html>
			'),

			(N'Donate',
			N'<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
			<html xmlns="http://www.w3.org/1999/xhtml" xmlns="http://www.w3.org/1999/xhtml" style="font-family: ''Helvetica Neue'', Helvetica, Arial, sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;">
			<head>
			<meta name="viewport" content="width=device-width" />
			<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
			<title>Billing e.g. invoices and receipts</title>

			<style>img {
			max-width: 100%;
			}
			body {
			-webkit-font-smoothing: antialiased; -webkit-text-size-adjust: none; width: 100% !important; height: 100%; line-height: 1.6em;
			}
			body {
			background-color: #f6f6f6;
			}
			@@media only screen and (max-width: 640px) {
				body {
				padding: 0 !important;
				}
				h1 {
				font-weight: 800 !important; margin: 20px 0 5px !important;
				}
				h2 {
				font-weight: 800 !important; margin: 20px 0 5px !important;
				}
				h3 {
				font-weight: 800 !important; margin: 20px 0 5px !important;
				}
				h4 {
				font-weight: 800 !important; margin: 20px 0 5px !important;
				}
				h1 {
				font-size: 22px !important;
				}
				h2 {
				font-size: 18px !important;
				}
				h3 {
				font-size: 16px !important;
				}
				.container {
				padding: 0 !important; width: 100% !important;
				}
				.content {
				padding: 0 !important;
				}
				.content-wrap {
				padding: 10px !important;
				}
				.invoice {
				width: 100% !important;
				}
			}
			</style></head>

			<body itemscope="" itemtype="http://schema.org/EmailMessage" style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; -webkit-font-smoothing: antialiased; -webkit-text-size-adjust: none; width: 100% !important; height: 100%; line-height: 1.6em; margin: 0;" bgcolor="#f6f6f6">

			<table style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; width: 100%; margin: 0;" bgcolor="#f6f6f6"><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;" valign="top"></td>
					<td width="600" style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; display: block !important; max-width: 600px !important; clear: both !important; margin: 0 auto;" valign="top">
						<div style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; max-width: 600px; display: block; margin: 0 auto; padding: 20px;">
							<table width="100%" cellpadding="0" cellspacing="0" style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; border-radius: 3px; margin: 0; border: 1px solid #e9e9e9;" bgcolor="#fff"><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0; padding: 20px;" align="center" valign="top">
										<table width="100%" cellpadding="0" cellspacing="0" style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0 0 20px;" valign="top">
													<h1 style="font-family: ''Helvetica Neue'',Helvetica,Arial,''Lucida Grande'',sans-serif; box-sizing: border-box; font-size: 32px; color: #000; line-height: 1.2em; font-weight: 500; margin: 40px 0 0;" align="center">Оплата в размере @Model.Donate.Sum @Model.Donate.Currency успешно проведена</h1>
												</td>
											</tr><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0 0 20px;" valign="top">
													<h2 style="font-family: ''Helvetica Neue'',Helvetica,Arial,''Lucida Grande'',sans-serif; box-sizing: border-box; font-size: 24px; color: #000; line-height: 1.2em; font-weight: 400; margin: 40px 0 0;" align="center">Спасибо, что пользуетесь сервисом ROCKET</h2>
												</td>
											</tr><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0 0 20px;" align="center" valign="top">
													<table style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; text-align: left; width: 80%; margin: 40px auto;"><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0; padding: 5px 0;" valign="top">@Model.Donate.Receiver.FirstName @Model.Donate.Receiver.LastName<br style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;" /><br style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;" />@DateTime.Now</td>
														</tr><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0; padding: 5px 0;" valign="top">
																<table cellpadding="0" cellspacing="0" style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; width: 100%; margin: 0;"><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; border-top-width: 1px; border-top-color: #eee; border-top-style: solid; margin: 0; padding: 5px 0;" valign="top">Донат</td>
																		<td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; border-top-width: 1px; border-top-color: #eee; border-top-style: solid; margin: 0; padding: 5px 0;" align="right" valign="top">@Model.Donate.Sum @Model.Donate.Currency</td>
																	</tr></table></td>
														</tr></table></td>
											</tr><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0 0 20px;" align="center" valign="top">
													<a href="http://www.mailgun.com" style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; color: #348eda; text-decoration: underline; margin: 0;">Перейти на главную страницу ROCKET</a>
												</td>
											</tr><tr style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;"><td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0 0 20px;" align="center" valign="top">
								ул. Скрыганова, 14, 5-й этаж, г. Минск, Республика Беларусь                 
												</td>
											</tr></table></td>
								</tr></table><div style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; width: 100%; clear: both; color: #999; margin: 0; padding: 20px;">					
					</td>
					<td style="font-family: ''Helvetica Neue'',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;" valign="top"></td>
				</tr></table></body>
			</html>
		'),

		(N'Confirmation',
		N'<!doctype html>
		<html>
		  <head>
			<meta name="viewport" content="width=device-width">
			<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
			<title>Simple Transactional Email</title>
			<style>
			/* -------------------------------------
				INLINED WITH htmlemail.io/inline
			------------------------------------- */
			/* -------------------------------------
				RESPONSIVE AND MOBILE FRIENDLY STYLES
			------------------------------------- */
			@@media only screen and (max-width: 620px) {
			  table[class=body] h1 {
				font-size: 28px !important;
				margin-bottom: 10px !important;
			  }
			  table[class=body] p,
					table[class=body] ul,
					table[class=body] ol,
					table[class=body] td,
					table[class=body] span,
					table[class=body] a {
				font-size: 16px !important;
			  }
			  table[class=body] .wrapper,
					table[class=body] .article {
				padding: 10px !important;
			  }
			  table[class=body] .content {
				padding: 0 !important;
			  }
			  table[class=body] .container {
				padding: 0 !important;
				width: 100% !important;
			  }
			  table[class=body] .main {
				border-left-width: 0 !important;
				border-radius: 0 !important;
				border-right-width: 0 !important;
			  }
			  table[class=body] .btn table {
				width: 100% !important;
			  }
			  table[class=body] .btn a {
				width: 100% !important;
			  }
			  table[class=body] .img-responsive {
				height: auto !important;
				max-width: 100% !important;
				width: auto !important;
			  }
			}

			/* -------------------------------------
				PRESERVE THESE STYLES IN THE HEAD
			------------------------------------- */
			@@media all {
			  .ExternalClass {
				width: 100%;
			  }
			  .ExternalClass,
					.ExternalClass p,
					.ExternalClass span,
					.ExternalClass font,
					.ExternalClass td,
					.ExternalClass div {
				line-height: 100%;
			  }
			  .apple-link a {
				color: inherit !important;
				font-family: inherit !important;
				font-size: inherit !important;
				font-weight: inherit !important;
				line-height: inherit !important;
				text-decoration: none !important;
			  }
			  .btn-primary table td:hover {
				background-color: #34495e !important;
			  }
			  .btn-primary a:hover {
				background-color: #34495e !important;
				border-color: #34495e !important;
			  }
			}
			</style>
		  </head>
		  <body class="" style="background-color: #f6f6f6; font-family: sans-serif; -webkit-font-smoothing: antialiased; font-size: 14px; line-height: 1.4; margin: 0; padding: 0; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;">
			<table border="0" cellpadding="0" cellspacing="0" class="body" style="border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; background-color: #f6f6f6;">
			  <tr>
				<td style="font-family: sans-serif; font-size: 14px; vertical-align: top;">&nbsp;</td>
				<td class="container" style="font-family: sans-serif; font-size: 14px; vertical-align: top; display: block; Margin: 0 auto; max-width: 580px; padding: 10px; width: 580px;">
				  <div class="content" style="box-sizing: border-box; display: block; Margin: 0 auto; max-width: 580px; padding: 10px;">

					<!-- START CENTERED WHITE CONTAINER -->
					<span class="preheader" style="color: transparent; display: none; height: 0; max-height: 0; max-width: 0; opacity: 0; overflow: hidden; mso-hide: all; visibility: hidden; width: 0;">Подтверждение регистрации Rocket</span>
					<table class="main" style="border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; background: #ffffff; border-radius: 3px;">

					  <!-- START MAIN CONTENT AREA -->
					  <tr>
						<td class="wrapper" style="font-family: sans-serif; font-size: 14px; vertical-align: top; box-sizing: border-box; padding: 20px;">
						  <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;">
							<tr>
							  <td style="font-family: sans-serif; font-size: 14px; vertical-align: top;">
								<p style="font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;">Здравствуйте, @Model.Confirmation.Receiver.FirstName!</p>
								<p style="font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;">Добро пожаловать на Rocket!<br> Активируйте свой аккаунт и начните пользоваться сервисом уже сейчас. Для этого подтвердите почту, указанную при регистрации.</p>
								<table border="0" cellpadding="0" cellspacing="0" class="btn btn-primary" style="border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; box-sizing: border-box;">
								  <tbody>
									<tr>
									  <td align="left" style="font-family: sans-serif; font-size: 14px; vertical-align: top; padding-bottom: 15px;">
										<table border="0" cellpadding="0" cellspacing="0" style="border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: auto;">
										  <tbody>
											<tr>
											  <td style="font-family: sans-serif; font-size: 14px; vertical-align: top; background-color: #3498db; border-radius: 5px; text-align: center;"> <a href=@Model.Confirmation.Url style="display: inline-block; color: #ffffff; background-color: #3498db; border: solid 1px #3498db; border-radius: 5px; box-sizing: border-box; cursor: pointer; text-decoration: none; font-size: 14px; font-weight: bold; margin: 0; padding: 12px 25px; text-transform: capitalize; border-color: #3498db;">Подтвердить</a> </td>
											</tr>
										  </tbody>
										</table>
									  </td>
									</tr>
								  </tbody>
								</table>
								<p style="font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;"></p>
								<p style="font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;">Удачи !</p>
							  </td>
							</tr>
						  </table>
						</td>
					  </tr>

					<!-- END MAIN CONTENT AREA -->
					</table>

					<!-- START FOOTER -->
					<div class="footer" style="clear: both; Margin-top: 10px; text-align: center; width: 100%;">
					  <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;">
						<tr>
						  <td class="content-block" style="font-family: sans-serif; vertical-align: top; padding-bottom: 10px; padding-top: 10px; font-size: 12px; color: #999999; text-align: center;">
							<span class="apple-link" style="color: #999999; font-size: 12px; text-align: center;">ул. Скрыганова, 14, 5-й этаж, г. Минск, Республика Беларусь</span>
							<br><a href="http://i.imgur.com/CScmqnj.gif" style="text-decoration: underline; color: #999999; font-size: 12px; text-align: center;"></a>.
						  </td>
						</tr>
						<tr>
						  <td class="content-block powered-by" style="font-family: sans-serif; vertical-align: top; padding-bottom: 10px; padding-top: 10px; font-size: 12px; color: #999999; text-align: center;">                    
						  </td>
						</tr>
					  </table>
					</div>
					<!-- END FOOTER -->

				  <!-- END CENTERED WHITE CONTAINER -->
				  </div>
				</td>
				<td style="font-family: sans-serif; font-size: 14px; vertical-align: top;">&nbsp;</td>
			  </tr>
			</table>
		  </body>
		</html>
		'),

		(N'Music',
		N'<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
		<html xmlns="http://www.w3.org/1999/xhtml" xmlns="http://www.w3.org/1999/xhtml">
			<head>
				<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
				<title>*|MC:SUBJECT|*</title>
        
			<style>.ReadMsgBody {
		width: 100%;
		}
		.ExternalClass {
		width: 100%;
		}
		.ExternalClass {
		line-height: 100%;
		}
		body {
		-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;
		}
		img {
		-ms-interpolation-mode: bicubic;
		}
		body {
		margin: 0; padding: 0;
		}
		img {
		border: 0; height: auto; line-height: 100%; outline: none; text-decoration: none;
		}
		body {
		height: 100% !important; margin: 0; padding: 0; width: 100% !important;
		}
		body {
		background-color: #DEE0E2;
		}
		.preheaderContent a:visited {
		color: #606060; font-weight: normal; text-decoration: underline;
		}
		.headerContent a:visited {
		color: #EB4102; font-weight: normal; text-decoration: underline;
		}
		.bodyContent a:visited {
		color: #EB4102; font-weight: normal; text-decoration: underline;
		}
		.footerContent a:visited {
		color: #606060; font-weight: normal; text-decoration: underline;
		}
		@@media only screen and (max-width: 480px) {
		  body {
			-webkit-text-size-adjust: none !important;
		  }
		  table {
			-webkit-text-size-adjust: none !important;
		  }
		  td {
			-webkit-text-size-adjust: none !important;
		  }
		  p {
			-webkit-text-size-adjust: none !important;
		  }
		  a {
			-webkit-text-size-adjust: none !important;
		  }
		  li {
			-webkit-text-size-adjust: none !important;
		  }
		  blockquote {
			-webkit-text-size-adjust: none !important;
		  }
		  body {
			width: 100% !important; min-width: 100% !important;
		  }
		  #bodyCell {
			padding: 10px !important;
		  }
		  #templateContainer {
			max-width: 600px !important; width: 100% !important;
		  }
		  h1 {
			font-size: 24px !important; line-height: 100% !important;
		  }
		  h2 {
			font-size: 20px !important; line-height: 100% !important;
		  }
		  h3 {
			font-size: 18px !important; line-height: 100% !important;
		  }
		  h4 {
			font-size: 16px !important; line-height: 100% !important;
		  }
		  #templatePreheader {
			display: none !important;
		  }
		  #headerImage {
			height: auto !important; max-width: 600px !important; width: 100% !important;
		  }
		  .headerContent {
			font-size: 20px !important; line-height: 125% !important;
		  }
		  .bodyContent {
			font-size: 18px !important; line-height: 125% !important;
		  }
		  .footerContent {
			font-size: 14px !important; line-height: 115% !important;
		  }
		  .footerContent a {
			display: block !important;
		  }
		}
		</style></head>
			<body leftmargin="0" marginwidth="0" topmargin="0" marginheight="0" offset="0" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; height: 100% !important; width: 100% !important; margin: 0; padding: 0;" bgcolor="#DEE0E2">
    			<center>
        			<table align="center" border="0" cellpadding="0" cellspacing="0" height="100%" width="100%" id="bodyTable" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse !important; height: 100% !important; width: 100% !important; margin: 0; padding: 0;" bgcolor="#DEE0E2">
            			<tr>
                			<td align="center" valign="top" id="bodyCell" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; height: 100% !important; width: 100% !important; border-top-width: 4px; border-top-color: #BBBBBB; border-top-style: solid; margin: 0; padding: 20px;">
                    	
                    			<table border="0" cellpadding="0" cellspacing="0" id="templateContainer" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse !important; width: 600px; border: 1px solid #bbbbbb;">
                        			<tr>
                            			<td align="center" valign="top" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt;">
                                	
											<table border="0" cellpadding="0" cellspacing="0" width="100%" id="templatePreheader" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse !important; border-bottom-width: 1px; border-bottom-color: #CCCCCC; border-bottom-style: solid;" bgcolor="#F4F4F4">
												<tr>
													<td valign="top" class="preheaderContent" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #808080; font-family: Helvetica; font-size: 10px; line-height: 125%; padding: 10px 20px;" mc:edit="preheader_content00" align="left">                                                
													</td>
                                            
													<td valign="top" width="180" class="preheaderContent" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #808080; font-family: Helvetica; font-size: 10px; line-height: 125%; padding: 10px 20px 10px 0;" mc:edit="preheader_content01" align="left">
														<br /><a href="*|ARCHIVE|*" target="_blank" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; color: #606060; font-weight: normal; text-decoration: underline;"></a>.
													</td>
                                            
												</tr>
											</table>
                                    
										</td>
									</tr>
                        			<tr>
                            			<td align="center" valign="top" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt;">
                                	
											<table border="0" cellpadding="0" cellspacing="0" width="100%" id="templateHeader" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse !important; border-top-width: 1px; border-top-color: #FFFFFF; border-top-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC; border-bottom-style: solid;" bgcolor="#F4F4F4">
												<tr>
													<td valign="top" class="headerContent" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #505050; font-family: Helvetica; font-size: 20px; font-weight: bold; line-height: 100%; padding: 0;" align="left">
                                            			<img src="https://i.pinimg.com/originals/6c/22/d9/6c22d9c6816f1f7108b45d2a9ce420a6.jpg" style="max-width: 600px; -ms-interpolation-mode: bicubic; height: auto; line-height: 100%; outline: none; text-decoration: none; border: 0;" id="headerImage" mc:label="header_image" mc:edit="header_image" mc:allowdesigner="" mc:allowtext="" />
													</td>
												</tr>
											</table>
                                    
										</td>
									</tr>
                        			<tr>
                            			<td align="center" valign="top" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt;">
                                	
											<table border="0" cellpadding="0" cellspacing="0" width="100%" id="templateBody" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse !important; border-top-width: 1px; border-top-color: #FFFFFF; border-top-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC; border-bottom-style: solid;" bgcolor="#F4F4F4">
												<tr>
													<td valign="top" class="bodyContent" mc:edit="body_content" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #505050; font-family: Helvetica; font-size: 14px; line-height: 150%; padding: 20px;" align="left">
														<h1 style="color: #202020 !important; display: block; font-family: Helvetica; font-size: 26px; font-style: normal; font-weight: bold; line-height: 100%; letter-spacing: normal; margin: 0 0 10px;" align="left">Здравствуйте, @Model.Music.Receivers[@Model.Count].FirstName!</h1>
														<h3 style="color: #202020 !important; display: block; font-family: Helvetica; font-size: 18px; font-style: normal; font-weight: normal; line-height: 100%; letter-spacing: normal; margin: 0 0 10px;" align="left">Мы рады сообщить что @Model.Music.ReleaseDate.ToShortDateString() состоялся<br></h3>
														<h3 style="color: #202020 !important; display: block; font-family: Helvetica; font-size: 18px; font-style: normal; font-weight: normal; line-height: 100%; letter-spacing: normal; margin: 0 0 10px;" align="left">музыкальный релиз <b>"@Model.Music.Title"</b><br>																									
								  <h3 style="color: #202020 !important; display: block; font-family: Helvetica; font-size: 18px; font-style: normal; font-weight: normal; line-height: 100%; letter-spacing: normal; margin: 0 0 10px;" align="left">
									исполнителя
									@for (int i = 0; i < @Model.Music.Musicians.Count; i++)
									{
									  if (@Model.Music.Musicians.Count == 1)
									  {
										<b>"@Model.Music.Musicians[i].FullName"</b>
									  }
									  else if (i == @Model.Music.Musicians.Count - 1)
									  {
										<b>@Model.Music.Musicians[i].FullName"</b>
									  }
									  else if (i == 0)
									  {
										<b>"@Model.Music.Musicians[i].FullName ft. </b>
									  }
									  else
									  {
										<b>@Model.Music.Musicians[i].FullName ft. </b>
									  }
									}
								  </h3>
														</h3>                                               
													</td>
												</tr>
											</table>
                                    
										</td>
									</tr>
                        			<tr>
                            			<td align="center" valign="top" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt;">
                                	
											<table border="0" cellpadding="0" cellspacing="0" width="100%" id="templateFooter" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse !important; border-top-width: 1px; border-top-color: #FFFFFF; border-top-style: solid;" bgcolor="#F4F4F4">                                  
												<tr>
													<td valign="top" class="footerContent" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #808080; font-family: Helvetica; font-size: 10px; line-height: 150%; padding: 0 20px 40px;" mc:edit="footer_content02" align="left">
                                            			<h3 style="color: #606060 !important; display: block; font-family: Helvetica; font-size: 16px; font-style: italic; font-weight: normal; line-height: 100%; letter-spacing: normal; margin: 0 0 10px;" align="left">С уважением, команда проекта Rocket!</h3> 
													</td>
												</tr>
											</table>
                                    
										</td>
									</tr>
								</table>
                        
							</td>
						</tr>
					</table>
				</center>
			</body>
		</html>
		'),

		(N'Episode',
		N'<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
		<html xmlns="http://www.w3.org/1999/xhtml" xmlns="http://www.w3.org/1999/xhtml">
			<head>
				<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
				<title>*|MC:SUBJECT|*</title>
				
			<style>.ReadMsgBody {
		width: 100%;
		}
		.ExternalClass {
		width: 100%;
		}
		.ExternalClass {
		line-height: 100%;
		}
		body {
		-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;
		}
		img {
		-ms-interpolation-mode: bicubic;
		}
		body {
		margin: 0; padding: 0;
		}
		img {
		border: 0; height: auto; line-height: 100%; outline: none; text-decoration: none;
		}
		body {
		height: 100% !important; margin: 0; padding: 0; width: 100% !important;
		}
		body {
		background-color: #DEE0E2;
		}
		.preheaderContent a:visited {
		color: #606060; font-weight: normal; text-decoration: underline;
		}
		.headerContent a:visited {
		color: #EB4102; font-weight: normal; text-decoration: underline;
		}
		.bodyContent a:visited {
		color: #EB4102; font-weight: normal; text-decoration: underline;
		}
		.footerContent a:visited {
		color: #606060; font-weight: normal; text-decoration: underline;
		}
		@@media only screen and (max-width: 480px) {
		  body {
			-webkit-text-size-adjust: none !important;
		  }
		  table {
			-webkit-text-size-adjust: none !important;
		  }
		  td {
			-webkit-text-size-adjust: none !important;
		  }
		  p {
			-webkit-text-size-adjust: none !important;
		  }
		  a {
			-webkit-text-size-adjust: none !important;
		  }
		  li {
			-webkit-text-size-adjust: none !important;
		  }
		  blockquote {
			-webkit-text-size-adjust: none !important;
		  }
		  body {
			width: 100% !important; min-width: 100% !important;
		  }
		  #bodyCell {
			padding: 10px !important;
		  }
		  #templateContainer {
			max-width: 600px !important; width: 100% !important;
		  }
		  h1 {
			font-size: 24px !important; line-height: 100% !important;
		  }
		  h2 {
			font-size: 20px !important; line-height: 100% !important;
		  }
		  h3 {
			font-size: 18px !important; line-height: 100% !important;
		  }
		  h4 {
			font-size: 16px !important; line-height: 100% !important;
		  }
		  #templatePreheader {
			display: none !important;
		  }
		  #headerImage {
			height: auto !important; max-width: 600px !important; width: 100% !important;
		  }
		  .headerContent {
			font-size: 20px !important; line-height: 125% !important;
		  }
		  .bodyContent {
			font-size: 18px !important; line-height: 125% !important;
		  }
		  .footerContent {
			font-size: 14px !important; line-height: 115% !important;
		  }
		  .footerContent a {
			display: block !important;
		  }
		}
		</style></head>
			<body leftmargin="0" marginwidth="0" topmargin="0" marginheight="0" offset="0" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; height: 100% !important; width: 100% !important; margin: 0; padding: 0;" bgcolor="#DEE0E2">
    			<center>
        			<table align="center" border="0" cellpadding="0" cellspacing="0" height="100%" width="100%" id="bodyTable" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse !important; height: 100% !important; width: 100% !important; margin: 0; padding: 0;" bgcolor="#DEE0E2">
            			<tr>
                			<td align="center" valign="top" id="bodyCell" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; height: 100% !important; width: 100% !important; border-top-width: 4px; border-top-color: #BBBBBB; border-top-style: solid; margin: 0; padding: 20px;">
                    	
                    			<table border="0" cellpadding="0" cellspacing="0" id="templateContainer" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse !important; width: 600px; border: 1px solid #bbbbbb;">
                        			<tr>
                            			<td align="center" valign="top" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt;">
                                	
											<table border="0" cellpadding="0" cellspacing="0" width="100%" id="templatePreheader" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse !important; border-bottom-width: 1px; border-bottom-color: #CCCCCC; border-bottom-style: solid;" bgcolor="#F4F4F4">
												<tr>
													<td valign="top" class="preheaderContent" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #808080; font-family: Helvetica; font-size: 10px; line-height: 125%; padding: 10px 20px;" mc:edit="preheader_content00" align="left">                                                
													</td>
                                            
													<td valign="top" width="180" class="preheaderContent" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #808080; font-family: Helvetica; font-size: 10px; line-height: 125%; padding: 10px 20px 10px 0;" mc:edit="preheader_content01" align="left">
														<br /><a href="*|ARCHIVE|*" target="_blank" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; color: #606060; font-weight: normal; text-decoration: underline;"></a>.
													</td>
                                            
												</tr>
											</table>
                                    
										</td>
									</tr>
                        			<tr>
                            			<td align="center" valign="top" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt;">
                                	
											<table border="0" cellpadding="0" cellspacing="0" width="100%" id="templateHeader" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse !important; border-top-width: 1px; border-top-color: #FFFFFF; border-top-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC; border-bottom-style: solid;" bgcolor="#F4F4F4">
												<tr>
													<td valign="top" class="headerContent" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #505050; font-family: Helvetica; font-size: 20px; font-weight: bold; line-height: 100%; padding: 0;" align="left">
                                            			<img src="https://i.pinimg.com/originals/6c/22/d9/6c22d9c6816f1f7108b45d2a9ce420a6.jpg" style="max-width: 600px; -ms-interpolation-mode: bicubic; height: auto; line-height: 100%; outline: none; text-decoration: none; border: 0;" id="headerImage" mc:label="header_image" mc:edit="header_image" mc:allowdesigner="" mc:allowtext="" />
													</td>
												</tr>
											</table>
                                    
										</td>
									</tr>
                        			<tr>
                            			<td align="center" valign="top" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt;">
                                	
											<table border="0" cellpadding="0" cellspacing="0" width="100%" id="templateBody" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse !important; border-top-width: 1px; border-top-color: #FFFFFF; border-top-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC; border-bottom-style: solid;" bgcolor="#F4F4F4">
												<tr>
													<td valign="top" class="bodyContent" mc:edit="body_content" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #505050; font-family: Helvetica; font-size: 14px; line-height: 150%; padding: 20px;" align="left">
														<h1 style="color: #202020 !important; display: block; font-family: Helvetica; font-size: 26px; font-style: normal; font-weight: bold; line-height: 100%; letter-spacing: normal; margin: 0 0 10px;" align="left">Здравствуйте, @Model.Episode.Receivers[@Model.Count].FirstName!</h1>
														<h3 style="color: #202020 !important; display: block; font-family: Helvetica; font-size: 18px; font-style: normal; font-weight: normal; line-height: 100%; letter-spacing: normal; margin: 0 0 10px;" align="left">Мы рады сообщить что @Model.Episode.ReleaseDate.ToShortDateString() состоялся<br></h3>
														<h3 style="color: #202020 !important; display: block; font-family: Helvetica; font-size: 18px; font-style: normal; font-weight: normal; line-height: 100%; letter-spacing: normal; margin: 0 0 10px;" align="left">релиз <b>"@Model.Episode.EpisodeNumber"</b> серии <b>"@Model.Episode.SeasonNumber"</b> сезона сериала <b>"@Model.Episode.Title"</b></h3>                                               
													</td>
												</tr>
											</table>                                    
										</td>
									</tr>
                        			<tr>
                            			<td align="center" valign="top" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt;">
                                	
											<table border="0" cellpadding="0" cellspacing="0" width="100%" id="templateFooter" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse !important; border-top-width: 1px; border-top-color: #FFFFFF; border-top-style: solid;" bgcolor="#F4F4F4">                                  
												<tr>
													<td valign="top" class="footerContent" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #808080; font-family: Helvetica; font-size: 10px; line-height: 150%; padding: 0 20px 40px;" mc:edit="footer_content02" align="left">
                                            			<h3 style="color: #606060 !important; display: block; font-family: Helvetica; font-size: 16px; font-style: italic; font-weight: normal; line-height: 100%; letter-spacing: normal; margin: 0 0 10px;" align="left">С уважением, команда проекта Rocket!</h3> 
													</td>
												</tr>
											</table>
                                    
										</td>
									</tr>
								</table>
                        
							</td>
						</tr>
					</table>
				</center>
			</body>
		</html>
		');