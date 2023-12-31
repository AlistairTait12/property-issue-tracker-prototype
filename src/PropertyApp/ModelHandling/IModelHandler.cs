﻿using PropertyApp.Model;

namespace PropertyApp.ModelHandling;

public interface IModelHandler
{
    void InitModel();

    void ClearModel();

    void SetImagePath(string path);

    string GetImagePath();

    void SetTitle(string title);

    string GetTitle();

    void SetDescription(string description);

    string GetDescription();

    void SetLocation(IssueCoordinatesModel location);

    IssueCoordinatesModel GetIssueCoordinates();

    void SetCapturedDateAndTime(DateTime capturedDateAndTime);

    DateTime GetCapturedDateAndTime();
}
