using System.Collections.Generic;
using Model;

namespace DAO.Services
{
    public interface IReservationService
    {
        Reservation GetReservationById(int reservationId);
        List<Reservation> GetAllReservations();
        void AddReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void CancelReservation(int reservationId);
    }
}
