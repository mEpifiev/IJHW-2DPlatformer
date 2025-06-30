public class MedicinePool : GameObjectPool<Medicine>
{
    protected override void OnGetObject(Medicine medicine)
    {
        base.OnGetObject(medicine);
        medicine.PickUp += OnMedicinePickedUp;
    }

    protected override void OnReleaseObject(Medicine medicine)
    {
        medicine.PickUp -= OnMedicinePickedUp;
        base.OnReleaseObject(medicine);
    }

    private void OnMedicinePickedUp(Medicine medicine)
    {
        Release(medicine);
    }
}