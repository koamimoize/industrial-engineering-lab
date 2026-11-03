# Literature Review Notes — IRL-001

## Paper 1
**Komary, M., Komarizadehasl, S., Tošić, N., Segura, I., Lozano-Galant, J. A., & Turmo, J. (2023).** “Low-Cost Technologies Used in Corrosion Monitoring.” *Sensors*, 23(3), 1309.  
DOI: https://doi.org/10.3390/s23031309  
Open access: https://pmc.ncbi.nlm.nih.gov/articles/PMC9920423/

### What kind of paper is it?
A review of low-cost technologies used to monitor corrosion. The authors examine electrochemical approaches and physical approaches, including sensor systems and data-acquisition methods. Their review screened literature indexed in Scopus and discusses 90 selected articles.

### Main points relevant to IRL-001
1. **Corrosion monitoring is multidisciplinary.** Corrosion involves interacting material and environmental phases. A useful monitoring approach may need more than one measurement method.
2. **Monitoring systems have several layers.** A typical architecture includes a sensor/probe, a data-acquisition component, and a data-processing/storage component.
3. **Low-cost does not automatically mean equivalent performance.** Commercial systems can be expensive, while low-cost prototypes involve trade-offs in sensitivity, durability, interpretation, and field suitability.
4. **Electrochemical methods can be powerful but technically demanding.** The review discusses EIS, linear polarization resistance, galvanic methods, and electrochemical noise. Some methods require electrodes, electrolyte contact, and specialized interpretation.
5. **Physical methods offer alternative routes.** The review covers electrical resistance, radio-frequency methods, optical fibers, ultrasonic methods, electromagnetic induction, and image recognition.
6. **Image analysis is a relevant low-cost direction.** The authors identify image-recognition approaches as an emerging route for documenting and quantifying visible corrosion-related changes. This supports exploring standardized smartphone photography, but it does not validate the exact protocol proposed here.
7. **Open-source data acquisition is promising.** The review discusses microcontrollers such as Arduino and open-source software as ways to build accessible monitoring systems.

### What this paper does NOT establish for our experiment
- It does not prove that smartphone photographs of ordinary nails provide a validated corrosion rate.
- It does not make visible rust area equivalent to metal loss or penetration depth.
- It does not establish that a 14-day, 15-nail experiment can support industrial conclusions.
- It does not validate the proposed exposure groups or their exact liquid concentrations.

### How it informs our project
The article supports the broader research direction: accessible corrosion monitoring is a real engineering topic, and monitoring combines sensing, data acquisition, and data processing. For the first pilot, we deliberately choose the simplest physical observation route—standardized photographs—because electrochemical methods are outside the current equipment and budget constraints.

The study should therefore be presented as an **exploratory image-documentation method**, not as a new corrosion sensor or a validated monitoring instrument.

### Questions for the next literature search
1. What image-acquisition conditions are required for reproducible corrosion segmentation?
2. Which color spaces or segmentation approaches are commonly used to estimate rust-covered area?
3. How do researchers validate image-based corrosion measurements against mass loss or other reference methods?
4. What are the limitations of using nails rather than standardized metal coupons?
5. Which low-cost environmental sensors are sufficiently accurate for recording temperature and relative humidity?

## Preliminary research gap (to be tested, not claimed as novel)
The review shows that image recognition has been explored for corrosion monitoring, but this first pilot is not yet a novelty claim. A defensible next step is to compare published image-based approaches, identify what validation they used, and then determine whether a simple, repeatable smartphone protocol has a useful role as a preliminary screening or educational tool.

## Reading log
- [x] Paper 1 identified and abstract/full-text content reviewed.
- [ ] Extract and summarize the specific image-recognition studies cited by Komary et al.
- [ ] Find primary studies validating image-based rust-area measurements.
- [ ] Compare visual-area methods with mass-loss standards and note what equipment they require.
