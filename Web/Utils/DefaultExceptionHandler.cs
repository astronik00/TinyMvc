﻿using Microsoft.AspNetCore.Diagnostics;

namespace Web.Utils;

/// <summary>
/// Обработчик всех ошибок на этапе продакшена
/// </summary>
/// <param name="logger"> Логгер </param>
public class DefaultExceptionHandler(ILogger<DefaultExceptionHandler> logger) : IExceptionHandler
{
    private const string BeautifulExceptionPage = """
                                                  <!DOCTYPE html>
                                                  <html>
                                                  <head>
                                                  <title> Error 503 </title>
                                                  <style>
                                                  @import url(https://fonts.googleapis.com/css?family=Open+Sans);html{background-color:#fefefe}body{font-family:Open Sans,Arial;color:#454545;font-size:16px;margin:2em auto;max-width:800px;padding:1em;line-height:1.4;text-align:justify}html.contrast body{color:#050505}html.contrast blockquote{color:#11151a}html.contrast blockquote:before{color:#262626}html.contrast a{color:#0051c9}html.contrast a:visited{color:#7d013e}html.contrast span.wr{color:#800}html.contrast span.mfw{color:#117e69}html.inverted{background-color:#010101}html.inverted body{color:#bababa}html.inverted div#invmode{color:#fff;background-color:#000}html.inverted blockquote{color:#dad0c7}html.inverted blockquote:before{color:#bfbfbf}html.inverted a{color:#07a}html.inverted a:visited{color:#ac5a82}html.inverted span.wr{color:#c0392b}html.inverted span.mfw{color:#19b496}a{color:#07a}a:visited{color:#941352}.noselect{-webkit-touch-callout:none;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none}span.citneed{vertical-align:top;font-size:.7em;padding-left:.3em}small{font-size:.4em}p.st{margin-top:-1em}div.fancyPositioning div.picture-left{float:left;width:40%;overflow:hidden;margin-right:1em}div.fancyPositioning div.picture-left img{width:100%}div.fancyPositioning div.picture-left p.caption{font-size:.7em}div.fancyPositioning div.tleft{float:left;width:55%}div.fancyPositioning div.tleft p:first-child{margin-top:0}div.fancyPositioning:after{display:block;content:"";clear:both}ul li img{height:1em}blockquote{color:#456;margin-left:0;margin-top:2em;margin-bottom:2em}blockquote span{float:left;margin-left:1rem;padding-top:1rem}blockquote author{display:block;clear:both;font-size:.6em;margin-left:2.4rem;font-style:oblique}blockquote author:before{content:"- ";margin-right:1em}blockquote:before{font-family:Times New Roman,Times,Arial;color:#666;content:open-quote;font-size:2.2em;font-weight:600;float:left;margin-top:0;margin-right:.2rem;width:1.2rem}blockquote:after{content:"";display:block;clear:both}@media screen and (max-width:500px){body{text-align:left}div.fancyPositioning div.picture-left,div.fancyPositioning div.tleft{float:none;width:inherit}blockquote span{width:80%}blockquote author{padding-top:1em;width:80%;margin-left:15%}blockquote author:before{content:"";margin-right:inherit}}span.visited{color:#941352}span.visited-maroon{color:#85144b}span.wr{color:#c0392b;font-weight:600;text-decoration:underline}div#contrast{color:#000;top:10px}div#contrast,div#invmode{cursor:pointer;position:absolute;right:10px;font-size:.8em;text-decoration:underline;-webkit-touch-callout:none;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none}div#invmode{color:#fff;background-color:#000;top:34px;padding:2px 5px}span.sb{color:#00e}span.sb,span.sv{cursor:not-allowed}span.sv{color:#551a8b}span.foufoufou{color:#444;font-weight:700}span.foufoufou:before{content:"";display:inline-block;width:1em;height:1em;margin-left:.2em;margin-right:.2em;background-color:#444}span.foufivfoufivfoufiv{color:#454545;font-weight:700}span.foufivfoufivfoufiv:before{content:"";display:inline-block;width:1em;height:1em;margin-left:.2em;margin-right:.2em;background-color:#454545}span.mfw{color:#16a085}a.kopimi,a.kopimi img.kopimi{display:block;margin-left:auto;margin-right:auto}a.kopimi img.kopimi{height:2em}p.fakepre{font-family:monospace;font-size:.9em}

                                                  body{
                                                  display: flex;
                                                  align-items: center;
                                                  justify-content: center;
                                                  }

                                                  html{
                                                  display: flex;
                                                  align-items: center;
                                                  justify-content: center;
                                                  height: 100vh;
                                                  }

                                                  .error-middle{
                                                  display: block;
                                                  vertical-align: middle;
                                                  }
                                                  </style>

                                                  </head>

                                                  <body>
                                                  <div class="error-middle">
                                                  <h1>Error 503 - Service Unavailable</h1>
                                                  <p> The service is unavailable.</p>
                                                  </div>
                                                  </body>
                                                  </html>
                                                  """;

    public async ValueTask<bool> TryHandleAsync(HttpContext ctx, Exception e, CancellationToken token)
    {
        logger.LogError(e, "Exception occurred: {Message}", e.Message);
        await ctx.Response.WriteAsync(BeautifulExceptionPage, token);
        return true;
    }
}