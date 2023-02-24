using System.ComponentModel;

namespace WorkerControl.Models;

public class WorkerControlModel
{
    private readonly BackgroundWorker _worker;

    private string _state;
    private bool _workerReportsProgress;
    private bool _workerSupportsCancellation;
    
    private DoWorkEventHandler _doWork;
    private ProgressChangedEventHandler _progressChanged;
    private RunWorkerCompletedEventHandler _runWorkerCompleted;
    
    public WorkerControlModel()
    {
        _worker = new BackgroundWorker();
        _state = "STOPPED";
        _workerReportsProgress = false;
        _workerSupportsCancellation = false;
        _worker.WorkerReportsProgress = _workerReportsProgress;
        _worker.WorkerSupportsCancellation = _workerSupportsCancellation;
    }
    
    public void SetWorkerReportsProgress(bool value)
    {
        _worker.WorkerReportsProgress = value;
    }
        
    public void SetWorkerSupportsCancellation(bool value)
    {
        _worker.WorkerSupportsCancellation = value;
    }

    public void SetWork(DoWorkEventHandler handler)
    {
        _doWork = handler;
        _worker.DoWork += _doWork;
    }

    public void SetProgressChanged(ProgressChangedEventHandler handler)
    {
        _progressChanged = handler;
        _worker.ProgressChanged += _progressChanged;
    }

    public void SetRunWorkerCompleted(RunWorkerCompletedEventHandler handler)
    {
        _runWorkerCompleted = handler;
        _worker.RunWorkerCompleted += _runWorkerCompleted;
    }

    public string GetState()
    {
        return _state;
    }
    
    public void ReportProgress(int progress)
    {
        _worker.ReportProgress(progress);
    }

    public void Start()
    {
        _worker.RunWorkerAsync();
        _state = "RUNNING";
    }
}