﻿using app.web.core;
using app.web.core.aspnet;

namespace app.web.application
{
  public class ViewReport<ReportModel,Query> : ISupportAStory where Query : IFetchInformation<ReportModel>,new()
  {
    IDisplayReports display_engine;
    Query query;

    public ViewReport(IDisplayReports display_engine)
    {
      this.display_engine = display_engine;
      this.query = new Query();
    }

    public ViewReport():this(new WebFormDisplayEngine())
    {
    }

    public void run(IProvideDetailsForACommand request)
    {
      display_engine.display(query.fetch_using(request));
    }
  }
}