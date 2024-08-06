namespace FileManagementApp.Services;

public interface IFileOpenerService
{
    void OpenFile(string path);

    bool CanOpenFile(string path);
}