# Runtime Comparison: Deterministic vs. Randomized QuickSort

## Overview
This project analyzes the efficiency trade-offs between **Deterministic QuickSort**, which selects a fixed pivot, and **Randomized QuickSort**, which introduces variability in pivot selection. The goal is to measure execution times and determine whether randomness offers an advantage in sorting large datasets.

![image](https://github.com/user-attachments/assets/dd60519b-7ec6-4655-9e91-832b6926aa7a)

## Project Structure
- **Sorting Algorithm Implementation** → Deterministic and Randomized QuickSort methods.
- **Performance Benchmarking** → Multiple test runs to observe variability and efficiency.
- **Containerized Execution** → `.NET processes sorting`, while **Python (Streamlit)** visualizes results.

## Objectives
✅ Compare the impact of fixed vs. randomized pivot selection on runtime.  
✅ Identify worst-case scenarios and how randomness mitigates inefficiencies.  
✅ Analyze execution trends for scalability in distributed environments.  

## Challenges & Optimizations
- **Avoiding worst-case pivot selections** → Randomized QuickSort reduces imbalanced partitions.  
- **Cross-language integration in Docker/Kubernetes** → `.NET Job` writes results, **Streamlit reads and visualizes** dynamically.  
- **Ensuring efficient execution for large datasets** → Fine-tuned pivot strategies improve runtime consistency.  

## Conclusion
Randomized QuickSort demonstrates **better overall stability and efficiency**, preventing extreme slowdowns due to poor pivot choices. This approach is particularly beneficial for high-performance computing scenarios.  
