using BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UnitOfWork : IDisposable
    {
        private MyFarmContext _context = new MyFarmContext();
        private StaffRepository _staffRepository;
        private GenericRepository<Cage> _cageRepository;
        private GenericRepository<Cattle> _cattleRepository;
        private GenericRepository<CattleByCage> _cattleByCageRepository;
        private GenericRepository<CattleDrug> _cattleDrugRepository;
        private GenericRepository<CattleFoodSchedule> _cattleFoodScheduleRepository;
        private GenericRepository<Drug> _drugRepository;
        private GenericRepository<Food> _foodRepository;
        private GenericRepository<StaffByCage> _staffByCageRepository;

        public StaffRepository StaffRepository
        {
            get
            {
                if (this._staffRepository == null)
                {
                    this._staffRepository = new StaffRepository(_context);
                }
                return _staffRepository;
            }
        }

        public GenericRepository<Cage> CageRepository
        {
            get
            {
                if (this._cageRepository == null)
                {
                    this._cageRepository = new GenericRepository<Cage>(_context);
                }
                return _cageRepository;
            }
        }

        public GenericRepository<Cattle> CattleRepository
        {
            get
            {
                if (this._cattleRepository == null)
                {
                    this._cattleRepository = new GenericRepository<Cattle>(_context);
                }
                return _cattleRepository;
            }
        }

        public GenericRepository<CattleByCage> CattleByCageRepository
        {
            get
            {
                if (this._cattleByCageRepository == null)
                {
                    this._cattleByCageRepository = new GenericRepository<CattleByCage>(_context);
                }
                return _cattleByCageRepository;
            }
        }

        public GenericRepository<CattleDrug> CattleDrugRepository
        {
            get
            {
                if (this._cattleDrugRepository == null)
                {
                    this._cattleDrugRepository = new GenericRepository<CattleDrug>(_context);
                }
                return _cattleDrugRepository;
            }
        }

        public GenericRepository<CattleFoodSchedule> CattleFoodScheduleRepository
        {
            get
            {
                if (this._cattleFoodScheduleRepository == null)
                {
                    this._cattleFoodScheduleRepository = new GenericRepository<CattleFoodSchedule>(_context);
                }
                return _cattleFoodScheduleRepository;
            }
        }

        public GenericRepository<Drug> DrugRepository
        {
            get
            {
                if (this._drugRepository == null)
                {
                    this._drugRepository = new GenericRepository<Drug>(_context);
                }
                return _drugRepository;
            }
        }

        public GenericRepository<Food> FoodRepository
        {
            get
            {
                if (this._foodRepository == null)
                {
                    this._foodRepository = new GenericRepository<Food>(_context);
                }
                return _foodRepository;
            }
        }

        public GenericRepository<StaffByCage> StaffByCageRepository
        {
            get
            {
                if (this._staffByCageRepository == null)
                {
                    this._staffByCageRepository = new GenericRepository<StaffByCage>(_context);
                }
                return _staffByCageRepository;
            }
        }

        public void SaveChanges() => _context.SaveChanges();

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
