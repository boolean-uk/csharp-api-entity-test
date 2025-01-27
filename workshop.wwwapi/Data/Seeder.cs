using System.Collections.Generic;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.Interface;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private bool useRandom;
        private List<List<string>> patientFirstSurNames = new()
        {
            new()
            {
                "Bob",
                "Frans",
                "Olaf",
                "Jurgen",
                "Tord",
                "Mord",
                "Gunn",
                "Hilda",
                "Frej",
                "Anka",
            },
            new()
            {
                "Smedsson",
                "Vikingsson",
                "Grensson",
                "Stensson",
                "Grusson",
                "Svärdsson",
                "Trässon",
            }
        };
        private List<List<string>> doctorFirstSurNames = new()
        {
            new()
            {
                "Dr.Mario",
                "Dr.Eggman",
                "Dr.Cortex",
                "Dr.Bosconovitch",
                "Dr.Faust",
                "Dr.Chakwas",
                "Dr.Nefarious",
                "Dr.Birkin",
                "Dr.Wily",
                "Dr.Kaufmann",
            },
            new()
            {
                "from 'Dr. Mario'",
                "from 'Sonic the Hedgehog'",
                "from 'Crash Bandicoot'",
                "from 'Tekken'",
                "from 'Guilty Gear'",
                "from 'Mass Effect'",
                "from 'Ratchet & Clank'",
                "from 'Resident Evil'",
                "from 'Mega Man'",
                "from 'Silent Hill'",
            }
        };

        private List<string> medicine_powerup_names = new()
        {
                "Vitamin Boost",
                "Antibiotic Pills",
                "Energy Drink",
                "Healing Capsule",
                "Immunity Boost",
                "Super Ring",
                "Invincibility Star",
                "Speed Boost",
                "Energy Drink",
                "Chili Dog",
                "Aku Aku Mask",
                "Wumpa Fruit",
                "Fruit Power-Up",
                "Mega Tiki Mask",
                "Invincibility Shield",
                "Health Potion",
                "Power Boost",
                "Focus Elixir",
                "Adrenaline Surge",
                "Revenge Meter",
                "Burst Charge",
                "Super Combo Elixir",
                "Overdrive Refill",
                "Instant Recovery",
                "Soul Shield",
                "Medigel Pack",
                "Stimulant",
                "Regen Serum",
                "Armor Plating",
                "Cloak Field",
                "Health Ammo Pack",
                "Armor Upgrade",
                "Health Bot",
                "Nanotech Boost",
                "Medi-Gun",
                "First - Aid Spray",
                "Herb Combination",
                "Medic Kit",
                "Bio-Regen Serum",
                "Vaccine",
                "Energy Tank",
                "Energy Capsule",
                "Power-Up Chips",
                "Refill Station",
                "Life Energy Capsule",
                "Health Drink",
                "First-Aid Kit",
                "Syringe",
                "Energy Bar",
                "Healing Crystal",
        };

        private List<string> medicine_descriptions = new()
        {
            "Take one to feel revitalized! May cause a sudden burst of enthusiasm and a desire to start organizing your entire life.",
            "For when you're feeling under the weather. Side effects may include feeling like you’ve just defeated an army of germs with ease.",
            "Take when you need to push through the day (or the next wave of enemies). May cause jittery movements and a craving for more power-ups.",
            "For when you're too stubborn to stop. Restore health one capsule at a time, but be warned: you may develop an addiction to these little miracles.",
            "Take for immediate resistance to status effects. Side effects may include an unreasonable amount of confidence and a desire to tackle impossible challenges.",
            "Take if you're feeling fragile. One ring restores you to full health—just don't lose track of your collection!",
            "Pop one of these and become invincible for a short time! Caution: May lead to excessive gloating and risky maneuvers.",
            "Take one dose and prepare to zip through obstacles. Note: Excessive speed may result in missed opportunities (and enemies).",
            "For those moments when you just need more juice to get through. May cause an uncontrollable need to run at full speed into danger.",
            "Take one of these for a full recovery and a dash of energy. Side effects may include sudden hunger and an urge to collect more snacks.",
            "For when you need protection from hits! Wear this mask and feel a sense of safety—at least for a few seconds.",
            "Take one to restore health. Warning: Eating too many may result in excessive bouncing and an overwhelming urge to collect more.",
            "For an instant boost to health and a temporary energy surge. May cause you to suddenly feel like you can take on the world!",
            "One mask, and you're ready for action! For protection and power—just don't get too cocky.",
            "Activate this for temporary invincibility! Use wisely—no one likes an overconfident adventurer who charges into danger without thinking.",
            "Take when you're feeling a little worse for wear. Effects: Instant healing with a side of 'I'm ready to take on anything'.",
            "For when you feel the need to feel mighty. Side effects may include overestimating your abilities and accidentally breaking things.",
            "Sip one to sharpen your focus and maximize your attack potential. Warning: May cause excessive staring at your enemies in a 'You don’t stand a chance' manner.",
            "Take to boost your performance under pressure. Side effects include running at full speed, even when it’s probably a terrible idea.",
            "Fill this meter up and take your revenge. May cause a temporary boost in confidence, but also a tendency to make rash decisions.",
            "Take to instantly charge up for a powerful counterattack. Be careful: this might make you overestimate how much power you have left.",
            "Perfect for when you need to land that perfect combo. May cause uncontrollable feelings of triumph and a desire to show off.",
            "Refills your special abilities, perfect for taking down tough enemies. Side effects may include a sudden urge to unleash everything in a blaze of glory.",
            "Use for an immediate heal. You won’t even have to wait! However, your enemies will likely be confused and possibly mad.",
            "Take when facing otherworldly threats. Provides protection, but may also make you feel like you can take on anything—even the supernatural.",
            "For an emergency recovery in the midst of combat. Just make sure you don’t run out of this stuff—running low will stress you out more than a couple of hostile aliens!",
            "Take for an instant jolt of energy. Effects: You’ll be unstoppable, for about 10 minutes, before you crash. Enjoy while it lasts!",
            "Sip this slowly and watch your wounds heal over time. It’s like having your own personal healing factor—just don’t get too cocky!",
            "Add this to your gear for extra protection. Side effects include feeling invincible and possibly overestimating your ability to face danger head-on.",
            "Activate this for invisibility and a chance to escape. Side effects may include accidental bumping into things while trying to hide.",
            "Take one of these if your health’s looking low. Be careful though—ammunition is better spent on survival, not just looking cool.",
            "Take one of these and your defenses will be stronger than ever. Warning: You may start thinking you're a walking tank.",
            "Deploy this little helper to heal you when things get rough. Side effects include feeling like you have a reliable friend who’s always there for you.",
            "Take this to enhance your healing process. You’ll heal faster and possibly start wishing you had this all the time.",
            "Use this to heal yourself or your team. Side effects: Your aim may get oddly precise when people are counting on you.",
            "Perfect for when you’re about to collapse. Use generously—but be aware, it may give you a false sense of security!",
            "Combine these herbs to restore health and get back to fighting. You might get a bit too creative with your herb-picking habit.",
            "Use this kit when you've been seriously hurt. One kit should heal you up, but don’t expect to be invincible forever.",
            "Take to regenerate your health, but be ready for your body to feel a bit...weird. Not everyone enjoys the taste of science.",
            "Take for protection against harmful effects. The sooner you take it, the better you’ll feel—and the fewer zombies you’ll have to deal with.",
            "Use one to fill your energy reserves and restore health. Side effects include a sudden sense of invincibility and the need to run headfirst into danger.",
            "Perfect for when you’re low on health but not energy. Just don’t forget where you left it—it might save you later!",
            "Pop one for an instant power boost. Side effects may include feeling like you could take on an army with your bare hands.",
            "Take a break and recharge here. Be warned: you’ll likely be over-prepared and overconfident afterward.",
            "Take for an instant burst of life energy. But don’t be surprised if you end up pushing your limits a bit too far afterward.",
            "For when you’re dehydrated from fighting all day. It’s not fancy, but it works wonders when you need it most.",
            "Use this when you're hurting. It’s a quick fix but not a long-term solution—don’t go running into another fire immediately!",
            "Inject for a quick recovery. Side effects: May cause a sudden confidence boost, but don’t get too reckless!",
            "Eat one for an immediate burst of energy. It’s the snack that keeps on giving... until you run out of them.",
            "Take one for a magical recovery. This might restore more than your health, but it definitely won’t solve your problems with ancient curses."
        };

        private List<Patient> _patients = new();
        private List<Doctor> _doctors = new();
        private List<Appointment> _appointments = new();
        private List<Prescription> _prescriptions = new();
        private List<Medicine> _medicines = new();
        private List<MedicinesInPrescription> _medicines_in_presccription = new();
        private int nonRandIncr(int cur, int max)
        {
            return (cur + 1) % max;
        }
        private int RandIncr(Random r, int max)
        {
            return r.Next(max);
        }

        
        public Seeder(bool useRandom)
        {

            initNames<Patient>(useRandom, patientFirstSurNames, _patients);
            initNames<Doctor>(useRandom, doctorFirstSurNames, _doctors);
            initAppointments("2025-02-10T10:15:00", 1);

            Random randomMed = new Random(1234);
            Random randomMedAmount = new Random(1234);

            for (int i = 0; i < medicine_powerup_names.Count; i++)
            {
                _medicines.Add(new Medicine
                    {
                        Id = i+1,
                        name = medicine_powerup_names[i % medicine_powerup_names.Count]
                    });
            }

            for (int i = 0; i < _appointments.Count; i++)
            {
                _prescriptions.Add(new Prescription
                {
                    Id = i+1,
                    DoctorId = _appointments[i % _appointments.Count].DoctorId,
                    PatientId = _appointments[i % _appointments.Count].PatientId,
                });

                var inserted = _prescriptions.Last();
                randomMed.Next();
                for (int j = 0; j < randomMedAmount.Next(1,5); j++)
                {
                    int rmed = randomMed.Next(_medicines.Count());
                    _medicines_in_presccription.Add(new MedicinesInPrescription
                    {
                        
                        MedicineId = _medicines[rmed % _medicines.Count()].Id,
                        PrescriptionId = inserted.Id,
                        note = medicine_descriptions[rmed % medicine_descriptions.Count()],
                        quantity = randomMedAmount.Next(1,5)
                    });
                    _medicines_in_presccription.RemoveAll(
                        x => _medicines_in_presccription.FindAll(y => y.MedicineId == x.MedicineId).ToList().Count > 1);
                }


            }
        }

        private void initAppointments(string startDate, int inverval)
        {

            DateTime initialDate = DateTime.Parse(startDate).ToUniversalTime(); // must be universal time, or else migration error



            for (int i = 0; i < _doctors.Count(); i++)
            {
                _appointments.Add(new Appointment()
                {
                    
                    DoctorId = _doctors[i % _doctors.Count()].Id,
                    PatientId = _patients[i % _patients.Count()].Id,
                    Booking = initialDate.AddDays((double)(i * inverval))
                });
            }
            for (int i = 0; i < _doctors.Count(); i += 2)
            {
                _appointments.Add(new Appointment()
                {
                    DoctorId = _doctors[i % _doctors.Count()].Id,
                    PatientId = _patients[(i + 1) % _patients.Count()].Id,
                    Booking = initialDate.AddDays((double)(i * inverval))
                });
            }
        }

        private void initNames<T>(bool useRandom, List<List<string>> listOfStringLists, List<T> entries) where T : ISeedable,  new()
        {
            Random _counter = new Random();
            for (int i = 1; i <= 15; i++)
            {

                var fnames = listOfStringLists[0];
                var fnamesLen = listOfStringLists[0].Count();
                var lnames = listOfStringLists[1];
                var lnamesLen = listOfStringLists[1].Count();
                if (useRandom)
                    entries.Add(new T
                    {
                        Id = i,
                        FullName = $"{fnames[RandIncr(_counter, fnamesLen)]} {lnames[RandIncr(_counter, lnamesLen)]}"
                    });
                else
                    entries.Add(new T
                    {
                        Id = i,
                        FullName = $"{fnames[nonRandIncr(i, fnamesLen)]} {lnames[nonRandIncr(i, lnamesLen)]}"
                    });
            }
        }

        public List<Patient> Patients { get => _patients; }
        public List<Doctor> Doctors { get => _doctors; }
        public List<Appointment> Appointments { get => _appointments; }
        public List<Prescription> Prescriptions { get => _prescriptions; }
        public List<Medicine> Medicines { get => _medicines; }
        public List<MedicinesInPrescription> Medicines_in_presccription { get => _medicines_in_presccription; }
    }
}
